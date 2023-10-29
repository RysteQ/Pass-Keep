using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Views.Account.Popups;

public partial class AccountDetails : Popup
{
	public AccountDetails(AccountModel account)
	{
		InitializeComponent();
		InitalizeViewElements();
	}

	private void InitalizeViewElements()
    {
        ImagePlatformIcon.Source = account.PlatformIcon;
        LabelUsername.Text = account.Username;
        LabelPassword.Text = account.Password;
        LabelEmail.Text = account.Email;
    }
	
	private AccountModel account;
}