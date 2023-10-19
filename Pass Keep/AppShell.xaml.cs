using Pass_Keep.Views.Login;
using Pass_Keep.Views.Passwords;

namespace Pass_Keep;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(PasswordListPage), typeof(PasswordListPage));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}