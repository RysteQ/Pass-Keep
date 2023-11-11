using System.ComponentModel;

namespace Pass_Keep.Models.Password_Models;

public class AccountModel : INotifyPropertyChanged
{
    public Guid GUID { get; set; }

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

    private ImageSource platform_icon;
    public ImageSource PlatformIcon
    {
        get => this.platform_icon;
        set { this.platform_icon = value; OnPropertyChanged(nameof(PlatformIcon)); }
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;
}