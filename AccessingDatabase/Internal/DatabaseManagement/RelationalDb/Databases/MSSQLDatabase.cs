using System.Collections.Concurrent;

namespace AccessingDatabase.Internal.DatabaseManagement.RelationalDb.Databases;

internal sealed class MSSQLDatabase : RelationalDatabase
{
    private readonly static Lazy<MSSQLDatabase> _instance = new Lazy<MSSQLDatabase>(() => new MSSQLDatabase());

    internal static MSSQLDatabase GetInstance() => _instance.Value;

    private MSSQLDatabase() : base("MSSQLDatabase") { }

    public override async Task<TModel> ExecuteReaderAsync<TModel>(string query)
        => await base.ExecuteReaderAsync<TModel>(query);

    public override async Task<TModel[]> ExecuteReaderToArrayAsync<TModel>(string query)
        => await base.ExecuteReaderToArrayAsync<TModel>(query);

    public override async Task<object> ExecuteScalarAsync(string query)
        => await base.ExecuteScalarAsync(query);

    public override Task<int> ExecuteNonQueryAsync(string query)
        => base.ExecuteNonQueryAsync(query);
}