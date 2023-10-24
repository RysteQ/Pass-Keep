using Pass_Keep.Models.Password_Models;

namespace Pass_Keep.Services.Converters.Account_Converters;

internal static class AccountConverters
{
    public static AccountModel ConvertAccountDBToAccount(AccountModelDB account_model_db)
    {
        return new()
        {
            GUID = account_model_db.GUID,
            PlatformName = account_model_db.PlatformName,
            PlatformIcon = ImageSource.FromStream(() => new MemoryStream(account_model_db.PlatformIcon)),
            Username = account_model_db.Username,
            Email = account_model_db.Email,
            Password = account_model_db.Password,
        };
    }
}