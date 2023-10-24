using CommunityToolkit.Maui.Views;

namespace Pass_Keep.Views.Account.Popups;

public partial class PreAccountCreation : Popup
{
	public PreAccountCreation()
	{
		InitializeComponent();
	}

    private async void ShowCreateNewAccountPage(object sender, EventArgs e)
    {
		await Shell.Current.Navigation.PushAsync(new AccountCreationPage(EntryAccountName.Text));
		this.Close();
    }
}