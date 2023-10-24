using SQLite;

namespace Pass_Keep.Models.Password_Models;

public class AccountModelDB
{
    [PrimaryKey]
    public Guid GUID { get; set; }
    
    public byte[] PlatformIcon { get; set; }

    public string PlatformName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public long GCRecord { get; set; }
}