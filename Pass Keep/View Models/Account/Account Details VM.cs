using Pass_Keep.Models.Password_Models;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Account;

internal class AccountDetailsVM : INotifyPropertyChanged
{
    public AccountDetailsVM(AccountModel account)
    {
        this.Account = account;

        this.CommandCopyUsername = new(async () => await CopyUsername());
        this.CommandCopyEmail = new(async () => await CopyEmail());
        this.CommandCopyPassword = new(async () => await CopyPassword());
        this.CommandChangePasswordVisibility = new(ChangePasswordVisibility);
    }

    private async Task CopyUsername()
    {
        await Clipboard.SetTextAsync(this.Account.Username);
    }

    private async Task CopyEmail()
    {
        await Clipboard.SetTextAsync(this.Account.Username);
    }

    private async Task CopyPassword()
    {
        await Clipboard.SetTextAsync(this.Account.Username);
    }

    private void ChangePasswordVisibility()
    {
        this.HidePassword = !this.HidePassword;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string property_name) => this.PropertyChanged?.Invoke(this, new(property_name));


    public Command CommandCopyUsername { get; set; }
    public Command CommandCopyEmail { get; set; }
    public Command CommandCopyPassword { get; set; }
    public Command CommandChangePasswordVisibility { get; set; }

    public AccountModel Account { get; set; }

    private bool hide_password = true;
    public bool HidePassword
    {
        get => this.hide_password;
        set { this.hide_password = value; OnPropertyChanged(nameof(HidePassword)); }
    }
}