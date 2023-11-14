using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Pass_Keep.View_Models.Settings;
using Pass_Keep.Views.Settings.Popups;

namespace Pass_Keep.Views.Settings;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
    }
    private void OnLightThemeButtonClicked(object sender, EventArgs e)
    {
        DarkThemeButton.BackgroundColorTo(Color.FromArgb("#00000000"), 160, 200, Easing.Linear);
        DarkThemeButton.FadeTo(0.5, 200, Easing.Linear);
        DarkThemeButton.ScaleTo(0.8, 200, Easing.Linear);
        LightThemeButton.ScaleTo(1, 200, Easing.Linear);
        LightThemeButton.FadeTo(1, 200, Easing.Linear);
        LightThemeButton.BackgroundColorTo(Color.FromArgb("#FF5BBDCF"), 160, 200, Easing.Linear);
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

    private SettingsVM view_model;
}