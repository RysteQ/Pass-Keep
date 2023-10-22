using SQLite;

namespace Pass_Keep.Models.Password_Models;

public class AccountModel
{
    [PrimaryKey]
    public Guid GUID { get; set; }
    public string PlatformName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public long GCRecord { get; set; }
}