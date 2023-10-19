using Pass_Keep.View_Models.Passwords;

namespace Pass_Keep.Views.Passwords;

public partial class PasswordDetailsPage : ContentPage
{
	public PasswordDetailsPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

	private PasswordDetailVM view_model;
}