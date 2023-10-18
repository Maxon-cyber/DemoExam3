using Database.Cash;
using DemoExam.ModelClasses;
using DemoExam.ModelClasses.Product;
using DemoExam.ModelClasses.User;
using System.Collections.Concurrent;
using Microsoft.Data.SqlClient;

namespace AccessingDatabase.Internal.DatabaseManagement.RelationalDb;

internal sealed class ResultRelationalDbQuery : IQueryResult
{
    private readonly SqlCommand _command = default!;

    internal ResultRelationalDbQuery(SqlCommand? command)
        => _command = (command, command?.CommandText) is (null, null) ?
                        throw new ArgumentNullException() :
                        command;

    public async Task<int> GetNonQueryResultAsync()
    {
        int result = 0;

        await Task.Run(async () => result = await _command.ExecuteNonQueryAsync());

        return result;
    }

    public async Task<ConcurrentQueue<TModel>> GetReaderResultArrayAsync<TModel>()
        where TModel : class, IModel, new()
    {
        ConcurrentQueue<TModel> result = new ConcurrentQueue<TModel>();

        await Task.Run(async () =>
        {
            await using SqlDataReader reader = await _command.ExecuteReaderAsync();

            if (result is IUserModel user)
            {
                while (await reader.ReadAsync())
                {
                    user.Name = reader["Name"].ToString();
                    user.Role = reader["Role"].ToString();
                    user.Login = reader["Login"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Description = reader["Description"].ToString();

                    result.Enqueue(user as TModel);
                }
            }
            else if (result is IProductModel product)
            {
                while (await reader.ReadAsync())
                {
                    product.Title = reader["ProductName"]?.ToString();
                    product.Appearance = reader["Appearance"].ToString();
                    product.Category = reader["Category"]?.ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);

                    result.Enqueue(product as TModel);
                }
            }
        });

        return result ?? new ConcurrentQueue<TModel>();
    }

    public async Task<TModel> GetReaderResultAsync<TModel>()
        where TModel : class, IModel, new()
    {
        TModel? currentModel = new TModel();

        await Task.Run(async () =>
        {
            await using SqlDataReader reader = await _command.ExecuteReaderAsync();

            if (currentModel is IUserModel user)
            {
                while (await reader.ReadAsync())
                {
                    user.Role = reader["Role"].ToString();
                    user.Name = reader["Name"].ToString();
                    user.Login = reader["Login"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Description = reader["Description"].ToString();
                }

                currentModel = user as TModel;
            }
            else if (currentModel is IProductModel product)
            {
                while (await reader.ReadAsync())
                {
                    product.Title = reader["ProductName"]?.ToString();
                    product.Category = reader["Category"]?.ToString();
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.Description = reader["Description"].ToString();
                }

                currentModel = product as TModel;
            }
        });

        return currentModel ?? new TModel();
    }

    public async ValueTask DisposeAsync()
    {
        await _command.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        _command.Dispose();
        GC.SuppressFinalize(this);
    }
}