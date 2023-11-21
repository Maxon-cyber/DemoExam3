using DemoExam.ModelClasses;
using System.Collections.Concurrent;

namespace AccessingDatabase.Internal.DatabaseManagement;

public interface IQueryResult : IDisposable, IAsyncDisposable
{
    Task<int> GetNonQueryResultAsync<TModel>(TModel model)
          where TModel : class, IModel, new();
    Task<int> GetNonQueryResultAsync();
    Task<TModel> GetReaderResultAsync<TModel>()
        where TModel : class, IModel, new();
    Task<ConcurrentQueue<TModel>> GetReaderResultToArrayAsync<TModel>()
        where TModel : class, IModel, new();
}