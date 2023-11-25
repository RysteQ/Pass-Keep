using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Pass_Keep.Services.Converters.Account_Converters;
using Pass_Keep.Services.Error_Informer;
using Pass_Keep.Resources.Translations.View_Models.Accounts.Account_List_Page;

namespace Pass_Keep.View_Models.Account;

internal class AccountListVM : INotifyPropertyChanged
{
    public AccountListVM() { }

    public async Task LoadAccounts()
    {
        new Thread(async () =>
        {
            List<object> accounts = new();

            try
            {
                accounts = await LocalDBAccountController.ReadAll(LocalDBController.database_connection);
            } catch (Exception ex) { await ErrorInformer.Inform(nameof(AccountListVM), nameof(LoadAccounts), Localization.Error_Loading_Accounts, ex); return; }

            this.Accounts.Clear();
            this.all_accounts.Clear();

            foreach (object account in accounts)
            {
                if ((account as AccountModelDB).GCRecord != 0)
                    continue;

                this.Accounts.Add(AccountConverters.ConvertAccountDBToAccount(account as AccountModelDB));
                this.all_accounts.Add(AccountConverters.ConvertAccountDBToAccount(account as AccountModelDB));
            }

            this.NoAccountsLoaded = !this.Accounts.Any();
        }).Start();
    }

    private void SearchPasswords()
    {
        this.Accounts.Clear();

        foreach (AccountModel account in this.all_accounts)
            if (account.PlatformName.ToUpper().Contains(this.SearchPassword.ToUpper().Trim()) || account.Username.ToUpper().Contains(this.SearchPassword.ToUpper().Trim()))
                this.Accounts.Add(account);

        this.NoAccountsLoaded = !this.Accounts.Any();
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