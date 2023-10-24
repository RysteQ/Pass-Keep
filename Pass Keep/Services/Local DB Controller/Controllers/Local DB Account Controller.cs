using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller.Interfaces;
using SQLite;

namespace Pass_Keep.Services.Local_DB_Controller.Controllers;

internal class LocalDBAccountController : ILocalDBModelController
{
    public static async Task Create(SQLiteAsyncConnection database_connection, object account_model) => await database_connection.InsertAsync(account_model as AccountModelDB);

    public static async Task Delete(SQLiteAsyncConnection database_connection, object account_model) => await database_connection.DeleteAsync(account_model as AccountModelDB);

    public static async Task<List<object>> Read(SQLiteAsyncConnection database_connection)
    {
        List<object> accounts = new();

        foreach (AccountModelDB account in await database_connection.Table<AccountModelDB>().ToListAsync())
            accounts.Add(account as object);

        return accounts;
    }

    public static async Task Update(SQLiteAsyncConnection database_connection, object account_model) => await database_connection.UpdateAsync(account_model as AccountModelDB);
}