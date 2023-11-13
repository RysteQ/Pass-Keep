using Pass_Keep.Models.Password_Models;
using Pass_Keep.View_Models.Account;

namespace Pass_Keep.Views.Account;

public partial class AccountEditPage : ContentPage
{
	public AccountEditPage(AccountModel account)
	{
		InitializeComponent();

		this.view_model = new(account);
		BindingContext = this.view_model;
	}

    private async void OnPasswordVisibilityImageButtonClicked(object sender, EventArgs e)
    {
        if (this.view_model.HidePassword)
            ImageButtonPasswordVisibility.Source = ImageSource.FromFile("visibility_on.svg");
        else
            ImageButtonPasswordVisibility.Source = ImageSource.FromFile("visibility_off.svg");

        await ImageButtonPasswordVisibility.ScaleTo(0.75, 50, Easing.Linear);
        await ImageButtonPasswordVisibility.ScaleTo(1, 50, Easing.Linear);
    }

    private async void OnSaveEditsButtonClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.view_model.Account.Username))
            await ShakeFrame(FrameUsername);

        if (string.IsNullOrEmpty(this.view_model.Account.Email))
            await ShakeFrame(FrameEmail);

        if (string.IsNullOrEmpty(this.view_model.Account.Password))
            await ShakeFrame(FramePassword);

        if (string.IsNullOrEmpty(this.view_model.Account.Username) == false && string.IsNullOrEmpty(this.view_model.Account.Email) == false && string.IsNullOrEmpty(this.view_model.Account.Password) == false)
            this.view_model.CommandSaveEdits.Execute(null);
    }

    private async Task ShakeFrame(Frame frame)
    {
        for (int i = 0; i < 10; i++)
            await frame.TranslateTo(i % 2 == 0 ? 10 : -10, 0, 50, Easing.Linear);

        await frame.TranslateTo(0, 0, 50, Easing.Linear);
    }

    private AccountEditVM view_model;
}