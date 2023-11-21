using DemoExam.ModelClasses;
using System.Data;

namespace AccessingDatabase.Internal.DatabaseManagement.RelationalDb.Databases;

public sealed class MSSQLDatabase<TModel> : RelationalDatabase<TModel>
    where TModel : class, IModel, new()
{
    public MSSQLDatabase() : base("MSSQLDatabase") { }

    public override async Task<TModel> ExecuteReaderAsync(string query)
        => await base.ExecuteReaderAsync(query);

    public override async Task<TModel[]> ExecuteReaderToArrayAsync(string query)
        => await base.ExecuteReaderToArrayAsync(query);

    public override async Task<int> ExecuteNonQueryAsync(string query, TModel[] model, long userId, CommandType commandType)
        => await base.ExecuteNonQueryAsync(query, model, userId, commandType);

    public override async Task<int> ExecuteNonQueryAsync(string query, TModel model, CommandType commandType)
        => await base.ExecuteNonQueryAsync(query, model, commandType);

    public override async Task<object> ExecuteScalarAsync(string query)
        => await base.ExecuteScalarAsync(query);

    public override async Task<int> ExecuteNonQueryAsync(string query)
        => await base.ExecuteNonQueryAsync(query);
}