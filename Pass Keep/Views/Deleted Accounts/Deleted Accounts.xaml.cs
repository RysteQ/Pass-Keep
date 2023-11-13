using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.View_Models.Deleted_Accounts;
using Pass_Keep.Resources.Translations.Code_Behind.Deleted_Accounts;
using CommunityToolkit.Maui.Views;
using Pass_Keep.Views.Deleted_Accounts.Popups;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Views.Deleted_Accounts;

public partial class DeletedAccounts : ContentPage
{
	public DeletedAccounts()
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
    
    private void AccountTapped(object sender, ItemTappedEventArgs e)
    {
        this.ShowPopup(new RecoverAccount(e.Item as AccountModel));
    }

    private DeletedAccountsVM view_model;
}