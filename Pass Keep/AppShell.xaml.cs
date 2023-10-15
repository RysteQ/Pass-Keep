using Pass_Keep.Views.Login;

namespace Pass_Keep;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}