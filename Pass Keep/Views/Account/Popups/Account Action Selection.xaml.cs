using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;
using Pass_Keep.Resources.Translations.Popups.Account_Action_Selection;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;

namespace Pass_Keep.Views.Account.Popups;

public partial class AccountActionSelection : Popup
{
	public AccountActionSelection(AccountModel account)
	{
		InitializeComponent();

		this.account = account;

		label_account_name.Text = this.account.Username;
		image_account_profile_image.Source = this.account.PlatformIcon;
	}

    private async void OnDetailsButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new AccountDetailsPage(this.account));
        await this.CloseAsync();
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new AccountEditPage(this.account));
        await this.CloseAsync();
    }
    
    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (await Shell.Current.DisplayAlert(Pass_Keep.Resources.Translations.Popup.Popup.Warning, Localization.AccountDeletion, Pass_Keep.Resources.Translations.Popup.Popup.Yes, Pass_Keep.Resources.Translations.Popup.Popup.No) == false)
            return;

        AccountModelDB to_delete = await LocalDBAccountController.Read(LocalDBController.database_connection, this.account.GUID) as AccountModelDB;

        to_delete.GCRecord = new Random().Next();

        try
        {
            await LocalDBAccountController.Update(LocalDBController.database_connection, to_delete);
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountActionSelection), nameof(OnDeleteButtonClicked), Localization.ErrorAccountDeletion, ex); return; }

        await this.CloseAsync();
    }

    private AccountModel account;
}