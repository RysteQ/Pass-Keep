using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;
using Pass_Keep.Resources.Translations.Popups.Recover_Account;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;

namespace Pass_Keep.Views.Deleted_Accounts.Popups;

public partial class RecoverAccount : Popup
{
	public RecoverAccount(AccountModel account)
    {
        InitializeComponent();

        this.account = account;

        LabelPlatformName.Text = this.account.PlatformName;
        LabelAccountName.Text = this.account.Username;
        ImageAccountProfileImage.Source = this.account.PlatformIcon;
    }

    private async void OnRecoverButtonClicked(object sender, EventArgs e)
    {
        AccountModelDB to_recover = await LocalDBAccountController.Read(LocalDBController.database_connection, this.account.GUID) as AccountModelDB;

        to_recover.GCRecord = 0;

        try
        {
            await LocalDBAccountController.Update(LocalDBController.database_connection, to_recover);
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(RecoverAccount), nameof(OnPermanentDeleteButtonClicked), Localization.Error_Recover_Account, ex); return; }

        await this.CloseAsync();
    }

    private async void OnPermanentDeleteButtonClicked(object sender, EventArgs e)
    {
        if (await Shell.Current.DisplayAlert(Pass_Keep.Resources.Translations.Popup.Popup.Warning, Localization.Question_Permanently_Delete_Account, Pass_Keep.Resources.Translations.Popup.Popup.Yes, Pass_Keep.Resources.Translations.Popup.Popup.No) == false)
            return;

        AccountModelDB to_delete = await LocalDBAccountController.Read(LocalDBController.database_connection, this.account.GUID) as AccountModelDB;

        try
        {
            await LocalDBAccountController.Delete(LocalDBController.database_connection, to_delete);
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(RecoverAccount), nameof(OnPermanentDeleteButtonClicked), Localization.Error_Permanent_Delete_Account, ex); return; }

        await this.CloseAsync();
    }

    private AccountModel account;
}