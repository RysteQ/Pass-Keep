using Pass_Keep.Models.Password_Models;
using SQLite;

namespace Pass_Keep.Services.Local_DB_Controller.Controllers;

internal class LocalDBAccountController
{
    public static async Task Create(SQLiteAsyncConnection database_connection, AccountModelDB account_model) => await database_connection.InsertAsync(account_model);

    public static async Task Delete(SQLiteAsyncConnection database_connection, AccountModelDB account_model) => await database_connection.DeleteAsync(account_model);

    public static async Task<List<object>> ReadAll(SQLiteAsyncConnection database_connection)
    {
        List<object> accounts = new();

        foreach (AccountModelDB account in await database_connection.Table<AccountModelDB>().ToListAsync())
            accounts.Add(account);

        return accounts;
    }
    
    public static async Task<object> Read(SQLiteAsyncConnection database_connection, Guid GUID) => (await database_connection.Table<AccountModelDB>().Where(account => account.GUID == GUID).ToListAsync()).First();

    public static async Task Update(SQLiteAsyncConnection database_connection, object account_model) => await database_connection.UpdateAsync(account_model as AccountModelDB);
}