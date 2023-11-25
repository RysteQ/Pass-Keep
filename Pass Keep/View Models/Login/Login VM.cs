using Pass_Keep.Resources.Translations.View_Models.Login;
using Pass_Keep.Resources.Translations.Popup;
using System.ComponentModel;
using Pass_Keep.Resources.Preferences;
using Pass_Keep.Views.Account;

namespace Pass_Keep.View_Models.Login;

internal class LoginVM : INotifyPropertyChanged
{
    public LoginVM()
    {
        this.CommandLogin = new(async () => await Login());
        this.CommandShowPassword = new(ShowPassword);
    }

    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(this.Password))
        {
            await Shell.Current.DisplayAlert(Popup.Warning, Localization.Username_Or_Password_Is_Required, Popup.Okay);
            return;
        }

        if (Preferences.Get(Preference.FirstTimeLogin, true))
        {
            await Register();
            return;
        }

        if (this.Password == Preferences.Get(Preference.Password, string.Empty))
            await Shell.Current.GoToAsync($"//{nameof(AccountListView)}/{nameof(AccountListView)}/{nameof(AccountListView)}");
        else
            await Shell.Current.DisplayAlert(Popup.Warning, Localization.Username_Or_Password_Is_Incorrect, Popup.Okay);
    }

    private async Task Register()
    {
        Preferences.Set(Preference.FirstTimeLogin, false);
        Preferences.Set(Preference.Password, this.Password);

        await Shell.Current.GoToAsync($"//{nameof(AccountListView)}/{nameof(AccountListView)}/{nameof(AccountListView)}");
    }

    private void ShowPassword()
    {
        this.IsPasswordVisible = !this.IsPasswordVisible;
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    public Command CommandLogin { get; set; }
    public Command CommandShowPassword { get; set; }

    private string password;
    public string Password
    {
        get => this.password;
        set { this.password = value.Trim(); OnPropertyChanged(nameof(Password)); }
    }

    private bool is_password_visible;
    public bool IsPasswordVisible
    {
        get => this.is_password_visible;
        set { this.is_password_visible = value; OnPropertyChanged(nameof(IsPasswordVisible)); }
    }
}