using CommunityToolkit.Maui.Views;
using Pass_Keep.Resources.Preferences;
using PopupLocalization = Pass_Keep.Resources.Translations.Popup.Popup;
using ChangePasswordPopupLocalization = Pass_Keep.Resources.Translations.Popups.Change_Password.Localization;

namespace Pass_Keep.Views.Settings.Popups;

public partial class ChangePasswordPopup : Popup
{
	public ChangePasswordPopup()
	{
		InitializeComponent();
	}

    private async void OnPasswordVisibilityImageButtonClicked(object sender, EventArgs e)
    {
        if (EntryPassword.IsPassword)
            ImageButtonPasswordVisibility.Source = ImageSource.FromFile("visibility_off.svg");
        else
            ImageButtonPasswordVisibility.Source = ImageSource.FromFile("visibility_on.svg");

        EntryPassword.IsPassword = !EntryPassword.IsPassword;

        await ImageButtonPasswordVisibility.ScaleTo(0.75, 50, Easing.Linear);
        await ImageButtonPasswordVisibility.ScaleTo(1, 50, Easing.Linear);
    }

    private async void OnRepeatPasswordVisibilityImageButtonClicked(object sender, EventArgs e)
    {
        if (EntryRepeatPassword.IsPassword)
            ImageButtonRepeatPasswordVisibility.Source = ImageSource.FromFile("visibility_off.svg");
        else
            ImageButtonRepeatPasswordVisibility.Source = ImageSource.FromFile("visibility_on.svg");

        EntryRepeatPassword.IsPassword = !EntryRepeatPassword.IsPassword;

        await ImageButtonRepeatPasswordVisibility.ScaleTo(0.75, 50, Easing.Linear);
        await ImageButtonRepeatPasswordVisibility.ScaleTo(1, 50, Easing.Linear);
    }

    private async void OnSavePasswordButtonClicked(object sender, EventArgs e)
    {
        if (EntryPassword.Text != EntryRepeatPassword.Text)
        {
            await Shell.Current.DisplayAlert(PopupLocalization.Error, ChangePasswordPopupLocalization.ErrorNewPasswordIsNotTheSameWithRepeatPassword, PopupLocalization.Aknowledge);
            return;
        }

        Preferences.Set(Preference.Password, EntryPassword.Text);

        await this.CloseAsync();
    }
}