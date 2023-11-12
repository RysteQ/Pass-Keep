using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Converters.Account_Converters;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Account;

internal class AccountCreationVM : INotifyPropertyChanged
{
    public AccountCreationVM(string platform_name)
    {
        this.CommandSelectedAccountImage = new(async () => await SelectedAccountImage());
        this.CommandCreateNewAccount = new(async () => await CreateNewAccount());

        this.NewAccount.PlatformName = platform_name;
    }

    private async Task SelectedAccountImage()
    {
        FileResult result = await MediaPicker.PickPhotoAsync();

        if (result == null)
            return;

        this.NewAccount.PlatformIcon = ImageSource.FromFile(result.FullPath);
        this.platform_icon = File.ReadAllBytes(result.FullPath);
        this.ImageSelected = true;
    }

    private async Task CreateNewAccount()
    {
        try
        {
            await LocalDBAccountController.Create(LocalDBController.database_connection, await AccountConverters.ConvertAccountToAccountDB(this.NewAccount, platform_icon));
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountCreationVM), nameof(CreateNewAccount), "", ex); }

        await Shell.Current.Navigation.PopAsync();
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    public Command CommandSelectedAccountImage { get; set; }
    public Command CommandCreateNewAccount { get; set; }

    public bool ImageSelected { get; private set; }
    public AccountModel NewAccount { get; set; } = new();

    private AccountModelDB new_account = new();
    private byte[] platform_icon = Array.Empty<byte>();
}