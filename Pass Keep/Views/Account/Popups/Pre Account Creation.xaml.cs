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
		if (string.IsNullOrEmpty(EntryPlatformName.Text))
        {
            for (int i = 0; i < 10; i++)
                await FramePlatformName.TranslateTo(i % 2 == 0 ? 10 : -10, 0, 50, Easing.Linear);

            await FramePlatformName.TranslateTo(0, 0, 50, Easing.Linear);

            return;
		}

		await Shell.Current.Navigation.PushAsync(new AccountCreationPage(EntryPlatformName.Text));
		this.Close();
    }
}