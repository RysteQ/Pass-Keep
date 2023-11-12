using Pass_Keep.Resources.Translations.Code_Behind.Accounts.Account_Creation_Page;
using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.View_Models.Account;

namespace Pass_Keep.Views.Account;

public partial class AccountCreationPage : ContentPage
{
	public AccountCreationPage(string platform_name)
	{
		InitializeComponent();

		this.view_model = new(platform_name);
		BindingContext = this.view_model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		this.view_model.NewAccount.PlatformIcon = ImageSource.FromFile("picture_picker");
    }

    protected override bool OnBackButtonPressed()
    {
        Dispatcher.Dispatch(async () =>
        {
            if (await Shell.Current.DisplayAlert(Popup.Attention, Localization.PopupLeavingWithAnUnsavedAccount, Popup.Yes, Popup.No))
                await Shell.Current.Navigation.PopAsync();
        });

        return true;
    }

    private async void ValidateAndCreateNewAccount(object sender, EventArgs e)
    {
        if (this.view_model.ImageSelected == false)
            await ShakeFrame(FramePlatformIcon);

        if (string.IsNullOrEmpty(this.view_model.NewAccount.Username))
            await ShakeFrame(FrameUsername);

        if (string.IsNullOrEmpty(this.view_model.NewAccount.Email))
            await ShakeFrame(FrameEmail);

        if (string.IsNullOrEmpty(this.view_model.NewAccount.Password))
            await ShakeFrame(FramePassword);

        if (this.view_model.ImageSelected && string.IsNullOrEmpty(this.view_model.NewAccount.Username) == false && string.IsNullOrEmpty(this.view_model.NewAccount.Email) == false && string.IsNullOrEmpty(this.view_model.NewAccount.Password) == false)
            this.view_model.CommandCreateNewAccount.Execute(null);
    }

    private async Task ShakeFrame(Frame frame)
    {
        for (int i = 0; i < 10; i++)
            await frame.TranslateTo(i % 2 == 0 ? 10 : -10, 0, 50, Easing.Linear);

        await frame.TranslateTo(0, 0, 50, Easing.Linear);
    }

    private AccountCreationVM view_model;
}