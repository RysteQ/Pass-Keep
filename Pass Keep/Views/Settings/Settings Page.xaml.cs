using Pass_Keep.View_Models.Settings;

namespace Pass_Keep.Views.Settings;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

		this.view_model = new();
		BindingContext = this.view_model;
	}

	private SettingsVM view_model;
}