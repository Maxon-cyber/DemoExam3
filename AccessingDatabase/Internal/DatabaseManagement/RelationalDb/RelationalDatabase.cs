using AccessingDatabase.ConfigurationFilePaths;
using AccessingDatabase.Internal.DatabaseManagement.DeserializeModels.ConnectionStringModels;
using DemoExam.ModelClasses;
using Deserialize;
using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;
using System.Data;

namespace AccessingDatabase.Internal.DatabaseManagement.RelationalDb;

public abstract class RelationalDatabase : IDatabase
{
    private readonly string? _connectionString = default;

    protected RelationalDatabase(string databaseName)
        => _connectionString = Deserializer<DatabaseModel>
                                .Deserialize(ConfigFilePath.DatabaseConnection)
                                ?.Database[databaseName]
                                ?.ConnectionString ?? throw new NullReferenceException();

    public virtual async Task<int> ExecuteNonQueryAsync(string query)
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand(query, connection);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(command);

        int result = 0;

        try
        {
            await connection.OpenAsync();
            result = queryResult.GetNonQueryResultAsync().Result;
        }
        catch (Exception)
        {

            throw;
        }

        return result;
    }

    public virtual async Task<int> ExecuteNonQueryAsync(string query, IModel user, CommandType commandType)
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand(query, connection);

        command.CommandType = commandType;

        return default;
    }

    public virtual async Task<ConcurrentQueue<TModel>> ExecuteReaderArrayAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand(query, connection);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(command);

        ConcurrentQueue<TModel> models = default!;

        try
        {
            await connection.OpenAsync();
            models = await queryResult.GetReaderResultArrayAsync<TModel>();
        }
        catch (SqlException ex)
        {

        }

        return models;
    }

    public virtual async Task<TModel> ExecuteReaderAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using SqlCommand command = new SqlCommand(query, connection);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(command);

        TModel model = default!;

        try
        {
            await connection.OpenAsync();
            model = await queryResult.GetReaderResultAsync<TModel>();
        }
        catch (SqlException ex)
        {
            throw;
        }

        return model;
    }

    public virtual async Task<object> ExecuteScalarAsync(string query)
    {
        return default;
    }

    ~RelationalDatabase()
        => Dispose();

    public virtual async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public virtual void Dispose()
        => GC.SuppressFinalize(this);
}