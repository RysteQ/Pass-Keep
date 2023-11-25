using CommunityToolkit.Maui.Views;
using Pass_Keep.Views.About.Popups;

namespace Pass_Keep.Views.About;

public partial class AboutView : ContentPage
{
	public AboutView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LabelFirstParagraph.Text = string.Format(LabelFirstParagraph.Text, Convert.ToInt16((DateTime.Now - new DateTime(2002, 10, 15)).TotalDays / 365));
    }

    private async void OnGithubAccountClicked(object sender, EventArgs e)
    {
        await Browser.Default.OpenAsync("https://github.com/RysteQ");
    }

    private async void OnGithubProfileImageButtonClicked(object sender, EventArgs e)
    {
        this.remaining_taps--;

        if (this.remaining_taps == 0)
        {
            await this.ShowPopupAsync(new MrFluffy());
            this.remaining_taps = 13;
        }
    }

    private int remaining_taps = 13;
}