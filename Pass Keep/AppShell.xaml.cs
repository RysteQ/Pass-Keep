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

        LabelVersion.Text = $"Version {AppInfo.VersionString}";

        await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }
}