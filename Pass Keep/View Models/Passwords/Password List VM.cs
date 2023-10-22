using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pass_Keep.Views.Passwords;

namespace Pass_Keep.View_Models.Passwords;

internal class PasswordListVM : INotifyPropertyChanged
{
    public PasswordListVM()
    {
        this.CommandCreateNewPassword = new(async () => await CreateNewPassword());
    }

    public async Task LoadAccounts()
    {
        List<object> accounts = await LocalDBAccountController.Read(LocalDBController.database_connection);
    }

    private async Task CreateNewPassword()
    {
        await Shell.Current.Navigation.PushAsync(new PasswordCreationPage());
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    public Command CommandCreateNewPassword { get; set; }

    private ObservableCollection<AccountModel> accounts;
    public ObservableCollection<AccountModel> Accounts
    {
        get => this.accounts;
        set { this.accounts = value; OnPropertyChanged(nameof(Accounts)); }
    }

    private string search_password;
    public string SearchPassword
    {
        get => this.search_password;
        set { this.search_password = value; }
    }
}