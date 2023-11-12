using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.ComponentModel;
using Pass_Keep.Resources.Translations.View_Models.Accounts.Account_Edit_Page;

namespace Pass_Keep.View_Models.Account;

internal class AccountEditVM : INotifyPropertyChanged
{
    public AccountEditVM(AccountModel account)
    {
        this.CommandSaveEdits = new(async () => await SaveEdit());
        this.CommandChangeImage = new(async () => await ChangeImage());

        this.Account = account;
    }

    private async Task ChangeImage()
    {
        FileResult image = await MediaPicker.PickPhotoAsync();

        if (image == null)
            return;

        this.Account.PlatformIcon = ImageSource.FromFile(image.FullPath);
        this.new_platform_image = File.ReadAllBytes(image.FullPath);
    }

    private async Task SaveEdit()
    {
        AccountModelDB account_model_db = new();

        try
        {
            account_model_db = await LocalDBAccountController.Read(LocalDBController.database_connection, this.Account.GUID) as AccountModelDB;
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountEditVM), nameof(SaveEdit), Localization.ErrorSavingEdits, ex); return; }

        if (this.new_platform_image != Array.Empty<byte>())
            account_model_db.PlatformIcon = this.new_platform_image;

        account_model_db.Username = this.Account.Username;
        account_model_db.Email = this.Account.Email;
        account_model_db.Password = this.Account.Password;

        try
        {
            await LocalDBAccountController.Update(LocalDBController.database_connection, account_model_db);
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountEditVM), nameof(SaveEdit), Localization.ErrorSavingEdits, ex); return; }

        await Shell.Current.Navigation.PopAsync();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));

    public Command CommandChangeImage { get; set; }
    public Command CommandSaveEdits { get; set; }

    private AccountModel account;
    public AccountModel Account
    {
        get => this.account;
        set { this.account = value; OnPropertyChanged(nameof(Account)); }
    }

    private byte[] new_platform_image = Array.Empty<byte>();
}