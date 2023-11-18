namespace Pass_Keep.Views.About;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LabelFirstParagraph.Text = string.Format(LabelFirstParagraph.Text, Convert.ToInt16((DateTime.Now - new DateTime(2002, 10, 15)).TotalDays / 365));
    }
}