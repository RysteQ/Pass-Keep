using Pass_Keep.Models.Password_Models;
using Pass_Keep.View_Models.Account;

namespace Pass_Keep.Views.Account;

public partial class AccountDetailsPage : ContentPage
{
	public AccountDetailsPage(AccountModel account)
	{
		InitializeComponent();

		this.view_model = new(account);
		BindingContext = this.view_model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


    }

    private AccountDetailsVM view_model;
}