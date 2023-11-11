using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller;
using Pass_Keep.Services.Local_DB_Controller.Controllers;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Account;

internal class AccountEditVM : INotifyPropertyChanged
{
    public AccountEditVM(AccountModel account)
    {
        this.CommandSaveEdits = new(async () => await SaveEdit());

        this.Account = account;
    }

    private async Task SaveEdit()
    {
        AccountModelDB account_model_db = await LocalDBAccountController.Read(LocalDBController.database_connection, this.Account.GUID) as AccountModelDB;

        account_model_db.Username = this.Account.Username;
        account_model_db.Email = this.Account.Email;
        account_model_db.Password = this.Account.Password;

        await LocalDBAccountController.Update(LocalDBController.database_connection, account_model_db);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));

    public Command CommandSaveEdits { get; set; }

    private AccountModel account;
    public AccountModel Account
    {
        get => this.account;
        set { this.account = value; OnPropertyChanged(nameof(Account)); }
    }
}