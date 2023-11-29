using CommunityToolkit.Maui.Views;
using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;

namespace Pass_Keep.Views.Settings.Popups;

public partial class CountdownPopup : Popup
{
	public CountdownPopup()
	{
		InitializeComponent();

		Countdown();
	}

	private void Countdown()
	{
        new Thread(() => {
            while (seconds_remaining > 1)
            {
                Dispatcher.Dispatch(() => LabelCountdown.Text = seconds_remaining.ToString());

                seconds_remaining--;
                Thread.Sleep(1000);
            }

            Dispatcher.Dispatch(() => LabelCountdown.Text = (seconds_remaining - 1).ToString());
            Dispatcher.Dispatch(() => ButtonDeleteDatabase.IsEnabled = true);
            Dispatcher.Dispatch(() => ButtonDeleteDatabase.FadeTo(1, 150, Easing.Linear));
        }).Start();
    }
    
    private async void OnButtonDeleteDatabaseClicked(object sender, EventArgs e)
    {
        List<object> all_accounts = await LocalDBAccountController.ReadAll(LocalDBController.database_connection);

        foreach (object account in all_accounts)
            await LocalDBAccountController.Delete(LocalDBController.database_connection, account as AccountModelDB);

        await CloseAsync();
    }

    private int seconds_remaining = 11;
}