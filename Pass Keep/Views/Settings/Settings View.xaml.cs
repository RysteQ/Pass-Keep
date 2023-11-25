using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Pass_Keep.Resources.Constants.Themes;
using Pass_Keep.Resources.Preferences;
using Pass_Keep.View_Models.Settings;
using Pass_Keep.Views.Settings.Popups;

namespace Pass_Keep.Views.Settings;

public partial class SettingsView : ContentPage
{
	public SettingsView()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (CheckboxAutoThemeEnabled.IsChecked)
        {
            LightThemeButton.IsEnabled = false;
            DarkThemeButton.IsEnabled = false;
            return;
        }

        if (Preferences.Get(Preference.AutoThemeEnabled, true) == false)
        {
            if (Preferences.Get(Preference.PreferredTheme, Themes.Dark_Theme) == Themes.Dark_Theme)
                OnDarkThemeButtonClicked(null, null);
            else
                OnLightThemeButtonClicked(null, null);
        }
    }

    private void OnCheckboxAutoThemeEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            App.Current.UserAppTheme = App.Current.PlatformAppTheme;

            DarkThemeButton.BackgroundColorTo(Color.FromArgb("#00000000"), 160, 200, Easing.Linear);
            DarkThemeButton.FadeTo(0.5, 200, Easing.Linear);
            DarkThemeButton.ScaleTo(0.8, 200, Easing.Linear);

            LightThemeButton.BackgroundColorTo(Color.FromArgb("#00000000"), 160, 200, Easing.Linear);
            LightThemeButton.FadeTo(0.5, 200, Easing.Linear);
            LightThemeButton.ScaleTo(0.8, 200, Easing.Linear);
        } else
        {
            if (Preferences.Get(Preference.PreferredTheme, Themes.Dark_Theme) == Themes.Dark_Theme)
            {
                OnDarkThemeButtonClicked(null, null);
                this.view_model.CommandChangeToDarkTheme.Execute(null);
            }
            else
            {
                OnLightThemeButtonClicked(null, null);
                this.view_model.CommandChangeToLightTheme.Execute(null);
            }
        }

        LightThemeButton.IsEnabled = !e.Value;
        DarkThemeButton.IsEnabled = !e.Value;
    }

    private void OnLightThemeButtonClicked(object sender, EventArgs e)
    {
        DarkThemeButton.BackgroundColorTo(Color.FromArgb("#00000000"), 160, 200, Easing.Linear);
        DarkThemeButton.FadeTo(0.5, 200, Easing.Linear);
        DarkThemeButton.ScaleTo(0.8, 200, Easing.Linear);
        LightThemeButton.ScaleTo(1, 200, Easing.Linear);
        LightThemeButton.FadeTo(1, 200, Easing.Linear);
        LightThemeButton.BackgroundColorTo(Color.FromArgb("#64B5F6"), 160, 200, Easing.Linear);
    }

    private void OnDarkThemeButtonClicked(object sender, EventArgs e)
    {
        LightThemeButton.BackgroundColorTo(Color.FromArgb("#00000000"), 160, 200, Easing.Linear);
        LightThemeButton.FadeTo(0.5, 200, Easing.Linear);
        LightThemeButton.ScaleTo(0.8, 200, Easing.Linear);
        DarkThemeButton.ScaleTo(1, 200, Easing.Linear);
        DarkThemeButton.FadeTo(1, 200, Easing.Linear);
        DarkThemeButton.BackgroundColorTo(Color.FromArgb("#FF2196F3"), 160, 200, Easing.Linear);
    }
    
    private async void OnChangePasswordButtonClicked(object sender, EventArgs e)
    {
        await this.ShowPopupAsync(new ChangePasswordPopup());
    }

    private async void OnDeleteAllAccountsButtonClicked(object sender, EventArgs e)
    {
        await this.ShowPopupAsync(new CountdownPopup());
    }

    private SettingsVM view_model;
}