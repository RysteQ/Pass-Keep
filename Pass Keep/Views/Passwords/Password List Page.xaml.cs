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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

		await this.view_model.LoadAccounts();
    }

    private PasswordListVM view_model;
}