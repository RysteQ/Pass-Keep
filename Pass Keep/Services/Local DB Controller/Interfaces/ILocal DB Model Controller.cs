using Pass_Keep.Models.Password_Models;
using SQLite;
using System.Collections;

namespace Pass_Keep.Services.Local_DB_Controller.Interfaces;

internal interface ILocalDBModelController 
{
    abstract static Task Create(SQLiteAsyncConnection database_connection, AccountModel account_model);
    abstract static Task<List<object>> Read(SQLiteAsyncConnection database_connection);
    abstract static Task Update(SQLiteAsyncConnection database_connection, AccountModel account_model);
    abstract static Task Delete(SQLiteAsyncConnection database_connection, AccountModel account_model);
}