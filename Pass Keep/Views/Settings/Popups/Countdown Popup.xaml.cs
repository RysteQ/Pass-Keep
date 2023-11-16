using CommunityToolkit.Maui.Views;

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

    private int seconds_remaining = 11;
}