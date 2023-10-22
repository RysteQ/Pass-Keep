using Pass_Keep.Models.Password_Models;
using SQLite;

namespace Pass_Keep.Services.Local_DB_Controller;

internal static class LocalDBController
{
    public static async Task InitDatabase()
    {
        if (database_connection != null)
            return;

        database_connection = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), local_database_filename), flags);

        await database_connection.CreateTableAsync<AccountModel>();
    }

    public static SQLiteAsyncConnection database_connection;
    private static readonly string local_database_filename = "local_db.db3";
    private const SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create;
}