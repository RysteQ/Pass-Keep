using System.ComponentModel;

namespace Pass_Keep.Models.Password_Models;

internal class AccountModel : INotifyPropertyChanged
{
    public Guid GUID { get; set; }

    public string PlatformName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    private ImageSource platform_icon;
    public ImageSource PlatformIcon
    {
        get => this.platform_icon;
        set { this.platform_icon = value; OnPropertyChanged(nameof(PlatformIcon)); }
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;
}