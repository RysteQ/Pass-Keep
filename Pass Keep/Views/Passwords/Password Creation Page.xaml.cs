using Pass_Keep.View_Models.Passwords;

namespace Pass_Keep.Views.Passwords;

public partial class PasswordCreationPage : ContentPage
{
	public PasswordCreationPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

	private PasswordCreationVM view_model;
}