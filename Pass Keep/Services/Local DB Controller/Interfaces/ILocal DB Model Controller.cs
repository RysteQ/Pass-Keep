using Pass_Keep.Models.Password_Models;
using SQLite;
using System.Collections;

namespace Pass_Keep.Services.Local_DB_Controller.Interfaces;

internal interface ILocalDBModelController 
{
    abstract static Task Create(SQLiteAsyncConnection database_connection, object model);
    abstract static Task<List<object>> ReadAll(SQLiteAsyncConnection database_connection);
    abstract static Task<object> Read(SQLiteAsyncConnection database_connection, Guid GUID);
    abstract static Task Update(SQLiteAsyncConnection database_connection, object model);
    abstract static Task Delete(SQLiteAsyncConnection database_connection, object model);
}