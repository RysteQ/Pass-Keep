using Pass_Keep.Resources.Preferences;
using Pass_Keep.Views.Login;

namespace Pass_Keep;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override async void OnResume()
    {
        base.OnResume();

        if (Preferences.Get(Preference.IsLoginEnabled, true) && Preferences.Get(Preference.IsReLoginEnabled, true))
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }
}