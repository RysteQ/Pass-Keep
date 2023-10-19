using Pass_Keep.Resources.Preferences;
using Pass_Keep.Resources.Translations.Code_Behind.Login;
using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.View_Models.Login;

namespace Pass_Keep.Views.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

        this.view_model = new();
        BindingContext = this.view_model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (Preferences.Get(Preference.FirstTimeLogin, true))
            await Shell.Current.DisplayAlert(Popup.Attention, Localization.First_Time_Login, Popup.Okay);
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private LoginVM view_model;
}