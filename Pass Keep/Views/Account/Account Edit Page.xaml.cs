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
    private void OnImageButtonClicked(object sender, EventArgs e)
    {

    }

    private AccountEditVM view_model;
}