using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Views.Deleted_Accounts.Popups;

public partial class RecoverAccount : Popup
{
	public RecoverAccount(AccountModel account)
	{
		InitializeComponent();

		this.account = account;
	}

	private AccountModel account;
}