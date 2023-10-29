using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pass_Keep.Services.Converters.Account_Converters;

namespace Pass_Keep.View_Models.Account;

internal class AccountListVM : INotifyPropertyChanged
{
    public AccountListVM() { }

    public async Task LoadAccounts()
    {
        List<object> accounts = await LocalDBAccountController.Read(LocalDBController.database_connection);

        this.Accounts.Clear();

        foreach (object account in accounts)
            this.Accounts.Add(AccountConverters.ConvertAccountDBToAccount(account as AccountModelDB));
    }

    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(property_name, new(property_name));
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<AccountModel> accounts = new();
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