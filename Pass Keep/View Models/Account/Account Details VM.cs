using Pass_Keep.Models.Password_Models;
using System.ComponentModel;

namespace Pass_Keep.View_Models.Account;

internal class AccountDetailsVM : INotifyPropertyChanged
{
    public AccountDetailsVM(AccountModel account)
    {
        this.account = account;

        this.CommandCopyUsername = new(async () => await CopyUsername());
        this.CommandCopyEmail = new(async () => await CopyEmail());
        this.CommandCopyPassword = new(async () => await CopyPassword());
        this.CommandChangePasswordVisibility = new(ChangePasswordVisibility);
    }

    private async Task CopyUsername()
    {
        await Clipboard.SetTextAsync(this.account.Username);
    }

    private async Task CopyEmail()
    {
        await Clipboard.SetTextAsync(this.account.Username);
    }

    private async Task CopyPassword()
    {
        await Clipboard.SetTextAsync(this.account.Username);
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

    public ImageSource AccountProfileImage { get => this.account.PlatformIcon; }
    public string PlatformName { get => this.account.PlatformName; }
    public string AccountUsername { get => this.account.Username; }
    public string AccountEmail { get => this.account.Email; }
    public string AccountPassword { get => this.account.Password; }

    private bool hide_password = true;
    public bool HidePassword
    {
        get => this.hide_password;
        set { this.hide_password = value; OnPropertyChanged(nameof(HidePassword)); }
    }

    private AccountModel account;
}