using Pass_Keep.Resources.Translations.Popup;
using Pass_Keep.View_Models.Deleted_Accounts;
using Pass_Keep.Resources.Translations.Code_Behind.Deleted_Accounts;
using CommunityToolkit.Maui.Views;
using Pass_Keep.Views.Deleted_Accounts.Popups;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Views.Deleted_Accounts;

public partial class DeletedAccountsView : ContentPage
{
	public DeletedAccountsView()
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
    
    private async void AccountTapped(object sender, ItemTappedEventArgs e)
    {
        await this.ShowPopupAsync(new RecoverAccount(e.Item as AccountModel));
        await this.view_model.LoadAccounts();
    }

    private DeletedAccountsVM view_model;
}