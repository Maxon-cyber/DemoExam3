using DemoExam.ModelClasses;
using System.Data;

namespace AccessingDatabase.Internal.DatabaseManagement;

public interface IDatabase<TModel> : IDisposable, IAsyncDisposable
    where TModel : class, IModel, new()
{
    Task<TModel[]> ExecuteReaderToArrayAsync(string query);

    Task<TModel> ExecuteReaderAsync(string query);

    Task<int> ExecuteNonQueryAsync(string query);

    Task<int> ExecuteNonQueryAsync(string query, TModel model, CommandType commandType);

    Task<object> ExecuteScalarAsync(string query);
}