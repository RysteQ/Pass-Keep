using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Views.Account.Popups;

public partial class AccountActionSelection : Popup
{
	public AccountActionSelection(AccountModel account)
	{
		InitializeComponent();

		this.account = account;

		label_account_name.Text = this.account.Username;
		image_account_profile_image.Source = this.account.PlatformIcon;
	}

    private void OnDetailsButtonClicked(object sender, EventArgs e)
    {
        // TODO
    }

    private void OnEditButtonClicked(object sender, EventArgs e)
    {
        // TODO
    }
    
    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        // TODO
    }

    private AccountModel account;
}