using Pass_Keep.Models.Password_Models;
using Pass_Keep.View_Models.Account;

namespace Pass_Keep.Views.Account;

public partial class AccountDetailsView : ContentPage
{
	public AccountDetailsView(AccountModel account)
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

    private AccountDetailsVM view_model;
}