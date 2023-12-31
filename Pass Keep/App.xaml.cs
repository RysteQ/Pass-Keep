﻿using Pass_Keep.Resources.Constants.Themes;
using Pass_Keep.Resources.Preferences;
using Pass_Keep.Services.Image_Picker;
using Pass_Keep.Views.Account;
using Pass_Keep.Views.Login;

namespace Pass_Keep;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();

        if (Preferences.Get(Preference.AutoThemeEnabled, true) == false)
        {
            if (Preferences.Get(Preference.PreferredTheme, Themes.Dark_Theme) == Themes.Dark_Theme)
                App.Current.UserAppTheme = AppTheme.Dark;
            else
                App.Current.UserAppTheme = AppTheme.Light;
        }
    }

    protected override async void OnResume()
    {
        base.OnResume();

        if (ImagePicker.PickingImage)
            return;

        if (Preferences.Get(Preference.IsLoginEnabled, true) && Preferences.Get(Preference.IsReLoginEnabled, true))
        {
            await Shell.Current.GoToAsync($"//{nameof(AccountListView)}/{nameof(AccountListView)}/{nameof(AccountListView)}");
            await Shell.Current.GoToAsync($"{nameof(LoginView)}");
        }
    }
}