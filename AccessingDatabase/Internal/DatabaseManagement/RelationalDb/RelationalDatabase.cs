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
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(new SqlCommand(query, connection));

        int result = 0;

        try
        {
            await connection.OpenAsync();
            result = await queryResult.GetNonQueryResultAsync();
        }
        catch (Exception)
        {

            
        }

        return result;
    }

    public virtual async Task<int> ExecuteNonQueryAsync<TModel>(string query, TModel model, CommandType commandType)
         where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(new SqlCommand(query, connection) { CommandType = commandType });
        
        int result = 0;

        try
        {
            await connection.OpenAsync();
            result = await queryResult.GetNonQueryResultAsync(model);
        }
        catch(SqlException ex)
        {

        }

        return result;
    }
    public virtual async Task<int> ExecuteNonQueryAsync<TModel>(string query, TModel[] model, long userId, CommandType commandType)
         where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(new SqlCommand(query, connection) { CommandType = commandType });

        int result = 0;

        try
        {
            await connection.OpenAsync();
            result = await queryResult.GetNonQueryResultAsync(model);
        }
        catch (SqlException ex)
        {

        }

        return result;
    }


    public virtual async Task<TModel[]> ExecuteReaderToArrayAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(new SqlCommand(query, connection));

        ConcurrentQueue<TModel> models = default!;

        try
        {
            await connection.OpenAsync();
            models = await queryResult.GetReaderResultToArrayAsync<TModel>();
        }
        catch (SqlException ex)
        {

        }

        return models.ToArray();
    }

    public virtual async Task<TModel> ExecuteReaderAsync<TModel>(string query)
        where TModel : class, IModel, new()
    {
        await using SqlConnection connection = new SqlConnection(_connectionString);
        await using ResultRelationalDbQuery queryResult = new ResultRelationalDbQuery(new SqlCommand(query, connection));

        TModel model = default!;

        try
        {
            await connection.OpenAsync();
            model = await queryResult.GetReaderResultAsync<TModel>();
        }
        catch (SqlException ex)
        {
            throw ex;
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