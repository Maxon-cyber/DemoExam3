using DemoExam.ModelClasses;
using System.Collections.Concurrent;

namespace AccessingDatabase.Internal.DatabaseManagement;

internal interface IQueryResult : IDisposable, IAsyncDisposable
{
    Task<int> GetNonQueryResultAsync();
    Task<TModel> GetReaderResultAsync<TModel>()
        where TModel : class, IModel, new();
    Task<ConcurrentQueue<TModel>> GetReaderResultArrayAsync<TModel>()
        where TModel : class, IModel, new();
}