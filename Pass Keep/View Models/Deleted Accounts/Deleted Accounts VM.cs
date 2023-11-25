using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Converters.Account_Converters;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using Pass_Keep.Resources.Translations.View_Models.Deleted_Accounts;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Deleted_Accounts;

class DeletedAccountsVM : INotifyPropertyChanged
{
    public DeletedAccountsVM() { }

    public async Task LoadAccounts()
    {
        List<object> accounts = new();

        try
        {
            accounts = await LocalDBAccountController.ReadAll(LocalDBController.database_connection);
        } catch (Exception ex) { await ErrorInformer.Inform(nameof(DeletedAccountsVM), nameof(LoadAccounts), Localization.Error_Loading_Accounts, ex); return; }

        this.Accounts.Clear();
        this.all_accounts.Clear();

        foreach (object account in accounts)
        {
            if ((account as AccountModelDB).GCRecord == 0)
                continue;

            this.all_accounts.Add(AccountConverters.ConvertAccountDBToAccount(account as AccountModelDB));
            this.Accounts.Add(AccountConverters.ConvertAccountDBToAccount(account as AccountModelDB));
        }

        this.NoAccountsLoaded = !this.Accounts.Any();
    }

    private void SearchPasswords()
    {
        this.Accounts.Clear();

        foreach (AccountModel account in this.all_accounts)
            if (account.PlatformName.ToUpper().Contains(this.SearchPassword.ToUpper().Trim()) || account.Username.ToUpper().Contains(this.SearchPassword.ToUpper().Trim()))
                this.Accounts.Add(account);

        this.NoAccountsLoaded = !this.Accounts.Any();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));

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

        set
        {
            this.search_password = value;

            if (string.IsNullOrEmpty(value))
            {
                this.Accounts.Clear();
                this.all_accounts.ForEach(account => this.Accounts.Add(account));
                this.NoAccountsLoaded = !this.Accounts.Any();
            } else
                SearchPasswords();
        }
    }
    
    private bool no_accounts_loaded;
    public bool NoAccountsLoaded
    {
        get => this.no_accounts_loaded;
        set { this.no_accounts_loaded = value; OnPropertyChanged(nameof(NoAccountsLoaded)); }
    }

    private List<AccountModel> all_accounts = new();
}