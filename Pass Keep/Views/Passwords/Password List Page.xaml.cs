using Pass_Keep.View_Models.Passwords;

namespace Pass_Keep.Views.Passwords;

public partial class PasswordListPage : ContentPage
{
	public PasswordListPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

	private PasswordListVM view_model;
}