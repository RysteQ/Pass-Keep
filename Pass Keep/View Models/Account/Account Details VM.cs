using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.View_Models.Account;

internal class AccountDetailsVM
{
    public AccountDetailsVM(AccountModel account)
    {
        this.account = account;
    }

    public ImageSource AccountProfileImage { get => this.account.PlatformIcon; }
    public string PlatformName { get => this.account.PlatformName; }
    public string AccountUsername { get => this.account.Username; }
    public string AccountEmail { get => this.account.Email; }
    public string AccountPassword { get => this.account.Password; }

    private AccountModel account;
}