using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Passwords;

internal class AccountCreationVM : INotifyPropertyChanged
{
    public AccountCreationVM(string platform_name)
    {
        this.CommandSelectedAccountImage = new(async () => await SelectedAccountImage());
        this.CommandCreateNewAccount = new(async () => await CreateNewAccount());

        this.PlatformName = platform_name;
    }

    private async Task SelectedAccountImage()
    {
        FileResult result = await MediaPicker.PickPhotoAsync();

        if (result == null)
            return;

        this.PlatformIconSource = ImageSource.FromFile(result.FullPath);
        this.platform_icon = File.ReadAllBytes(result.FullPath);
    }

    private async Task CreateNewAccount()
    {
        this.new_account.GUID = Guid.NewGuid();
        this.new_account.PlatformIcon = this.platform_icon;
        this.new_account.PlatformName = this.PlatformName;
        this.new_account.Username = this.Username;
        this.new_account.Email = this.Email;
        this.new_account.Password = this.Password;
        this.new_account.GCRecord = 0;

        await LocalDBAccountController.Create(LocalDBController.database_connection, this.new_account);
        await Shell.Current.Navigation.PopAsync();
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    public Command CommandSelectedAccountImage { get; set; }
    public Command CommandCreateNewAccount { get; set; }

    private ImageSource platform_icon_source;
    public ImageSource PlatformIconSource
    {
        get => this.platform_icon_source;
        set { this.platform_icon_source = value; OnPropertyChanged(nameof(PlatformIconSource)); }
    }

    private string platform_name;
    public string PlatformName
    {
        get => this.platform_name;
        set { this.platform_name = value; OnPropertyChanged(nameof(PlatformName)); }
    }

    private string username;
    public string Username
    {
        get => this.username;
        set { this.username = value; OnPropertyChanged(nameof(Username)); }
    }

    private string email;
    public string Email
    {
        get => this.email;
        set { this.email = value; OnPropertyChanged(nameof(Email)); }
    }

    private string password;
    public string Password
    {
        get => this.password;
        set { this.password = value; OnPropertyChanged(nameof(Password)); }
    }

    private string comments;
    public string Comments
    {
        get => this.comments;
        set { this.comments = value; OnPropertyChanged(nameof(Comments)); }
    }

    private AccountModelDB new_account = new();
    private byte[] platform_icon;
}