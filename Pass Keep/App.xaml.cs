using Pass_Keep.Resources.Preferences;
using Pass_Keep.Services.Image_Picker;
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

        if (ImagePicker.PickingImage)
            return;

        if (Preferences.Get(Preference.IsLoginEnabled, true) && Preferences.Get(Preference.IsReLoginEnabled, true))
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
    }
}