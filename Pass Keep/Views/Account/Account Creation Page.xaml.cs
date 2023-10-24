using Pass_Keep.View_Models.Passwords;

namespace Pass_Keep.Views.Account;

public partial class AccountCreationPage : ContentPage
{
	public AccountCreationPage(string platform_name)
	{
		InitializeComponent();

		this.view_model = new(platform_name);
		BindingContext = this.view_model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		this.view_model.PlatformIconSource = ImageSource.FromFile("picture_picker");
    }

    private AccountCreationVM view_model;
}