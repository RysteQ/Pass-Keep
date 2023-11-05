using Pass_Keep.View_Models.Account;
using Pass_Keep.Views.Account.Popups;
using CommunityToolkit.Maui.Views;

namespace Pass_Keep.Views.Account;

public partial class AccountListPage : ContentPage
{
	public AccountListPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await this.view_model.LoadAccounts();
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private void OpenPreAccountCreationPopup(object sender, EventArgs e)
    {
        this.ShowPopup(new PreAccountCreation());
    }

    private void OpenAccountActions(object sender, EventArgs e)
    {
        this.ShowPopup(new AccountActionSelection());
    }

    private AccountListVM view_model;
}