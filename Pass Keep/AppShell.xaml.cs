using Pass_Keep.Resources.Preferences;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Views.Account;
using Pass_Keep.Views.Login;

namespace Pass_Keep;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LocalDBController.InitDatabase();

        if (Preferences.Get(Preference.IsLoginEnabled, true))
            Shell.Current.GoToAsync($"{nameof(LoginView)}");
        else
            Shell.Current.GoToAsync($"//{nameof(AccountListView)}/{nameof(AccountListView)}/{nameof(AccountListView)}");
    }
}