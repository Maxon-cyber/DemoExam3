using DemoExam.ModelClasses;
using System.Collections.Concurrent;

namespace AccessingDatabase.Internal.DatabaseManagement;

public interface IDatabase : IDisposable, IAsyncDisposable
{
    Task<ConcurrentQueue<TModel>> ExecuteReaderArrayAsync<TModel>(string query)
        where TModel : class, IModel, new();
    Task<TModel> ExecuteReaderAsync<TModel>(string query)
        where TModel : class, IModel, new();
    Task<int> ExecuteNonQueryAsync(string query);
    Task<object> ExecuteScalarAsync(string query);
}