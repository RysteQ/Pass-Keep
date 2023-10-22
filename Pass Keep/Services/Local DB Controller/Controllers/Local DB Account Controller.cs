using Pass_Keep.Models.Password_Models;
using Pass_Keep.Services.Local_DB_Controller.Interfaces;
using SQLite;

namespace Pass_Keep.Services.Local_DB_Controller.Controllers;

internal class LocalDBAccountController : ILocalDBModelController
{
    public static async Task Create(SQLiteAsyncConnection database_connection, AccountModel account_model) => await database_connection.InsertAsync(account_model);

    public static async Task Delete(SQLiteAsyncConnection database_connection, AccountModel account_model) => await database_connection.DeleteAsync(account_model);

    public static async Task<List<object>> Read(SQLiteAsyncConnection database_connection)
    {
        List<object> accounts = new();

        foreach (AccountModel account in await database_connection.Table<AccountModel>().ToListAsync())
            accounts.Add(account as object);

        return accounts;
    }

    public static async Task Update(SQLiteAsyncConnection database_connection, AccountModel account_model) => await database_connection.UpdateAsync(account_model);
}