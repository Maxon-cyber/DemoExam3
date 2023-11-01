using AccessingDatabase.Internal.DatabaseManagement;
using DemoExam.ModelClasses;
using System.Collections.Concurrent;
using System.Data;

namespace AccessingDatabase.Internal.DatabaseManagement.NotRelationalDb;

public abstract class NotRelationalDatabase : IDatabase
{
    public virtual Task<int> ExecuteNonQueryAsync(string query)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TModel[]> ExecuteReaderArrayToAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        throw new NotImplementedException();
    }

    public virtual Task<object> ExecuteScalarAsync(string query)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TModel> ExecuteReaderAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    Task<TModel[]> IDatabase.ExecuteReaderToArrayAsync<TModel>(string query)
    {
        throw new NotImplementedException();
    }

    Task<int> IDatabase.ExecuteNonQueryAsync<TModel>(string query, TModel model, CommandType commandType)
    {
        throw new NotImplementedException();
    }
}