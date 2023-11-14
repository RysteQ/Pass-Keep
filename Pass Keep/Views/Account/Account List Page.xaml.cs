using Pass_Keep.View_Models.Account;
using Pass_Keep.Views.Account.Popups;
using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;

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

    private async void OpenPreAccountCreationPopup(object sender, EventArgs e)
    {
        await FrameCreateNewAccount.ScaleTo(0.8, 35, Easing.Linear);
        await FrameCreateNewAccount.ScaleTo(1, 35, Easing.Linear);

        this.ShowPopup(new PreAccountCreation());
    }

    private async void AccountTapped(object sender, ItemTappedEventArgs e)
    {
        await this.ShowPopupAsync(new AccountActionSelection(e.Item as AccountModel));
        await this.view_model.LoadAccounts();
    }

    private AccountListVM view_model;
}