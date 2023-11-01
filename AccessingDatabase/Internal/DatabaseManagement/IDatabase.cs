using DemoExam.ModelClasses;
using System.Data;

namespace AccessingDatabase.Internal.DatabaseManagement;

public interface IDatabase : IDisposable, IAsyncDisposable
{
    Task<TModel[]> ExecuteReaderToArrayAsync<TModel>(string query)
        where TModel : class, IModel, new();
    Task<TModel> ExecuteReaderAsync<TModel>(string query)
        where TModel : class, IModel, new();
    Task<int> ExecuteNonQueryAsync(string query);
    Task<int> ExecuteNonQueryAsync<TModel>(string query, TModel model, CommandType commandType)
        where TModel : class, IModel, new();
   Task<object> ExecuteScalarAsync(string query);
}