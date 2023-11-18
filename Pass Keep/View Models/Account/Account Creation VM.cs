using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Converters.Account_Converters;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Image_Picker;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Account;

internal class AccountCreationVM : INotifyPropertyChanged
{
    public AccountCreationVM(string platform_name)
    {
        this.CommandSelectedAccountImage = new(async () => await SelectedAccountImage());
        this.CommandCreateNewAccount = new(async () => await CreateNewAccount());
        this.CommandHidePassword = new(HidePasswordMethod);

        this.NewAccount.PlatformName = platform_name;
    }

    private async Task SelectedAccountImage()
    {
        FileResult result = await ImagePicker.PickImage();
        byte[] image_data = Array.Empty<byte>();
        IImage image;

        if (result == null)
            return;

        using (MemoryStream stream = new(File.ReadAllBytes(result.FullPath)))
            image = PlatformImage.FromStream(stream);

        using (Stream stream = image.Resize(256, 256, ResizeMode.Bleed).AsStream())
        {
            image_data = new byte[stream.Length];
            await stream.ReadAsync(image_data, 0, image_data.Length);
        }

        this.NewAccount.PlatformIcon = ImageSource.FromFile(result.FullPath);
        this.platform_icon = image_data;
        this.ImageSelected = true;
    }

    private async Task CreateNewAccount()
    {
        this.NewAccount.GUID = Guid.NewGuid();

        try
        {
            await LocalDBAccountController.Create(LocalDBController.database_connection, AccountConverters.ConvertAccountToAccountDB(this.NewAccount, platform_icon));
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountCreationVM), nameof(CreateNewAccount), "", ex); }

        await Shell.Current.Navigation.PopAsync();
    }

    private void HidePasswordMethod()
    {
        this.HidePassword = !this.HidePassword;
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    public Command CommandSelectedAccountImage { get; set; }
    public Command CommandCreateNewAccount { get; set; }
    public Command CommandHidePassword { get; set; }

    public bool ImageSelected { get; set; }
    public AccountModel NewAccount { get; set; } = new();

    private bool hide_password = true;
    public bool HidePassword
    {
        get => this.hide_password;
        set { this.hide_password = value; OnPropertyChanged(nameof(HidePassword)); }
    }

    private AccountModelDB new_account = new();
    private byte[] platform_icon = Array.Empty<byte>();
}