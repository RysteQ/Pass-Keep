using Pass_Keep.View_Models.Passwords;

namespace Pass_Keep.Views.Account;

public partial class AccountDetailsPage : ContentPage
{
	public AccountDetailsPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

	private AccountDetailVM view_model;
}