using DemoExam.ModelClasses;
using DemoExam.ModelClasses.Product;
using DemoExam.ModelClasses.User;
using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;

namespace AccessingDatabase.Internal.DatabaseManagement.RelationalDb;

internal sealed class ResultRelationalDbQuery : IQueryResult
{
    private readonly SqlCommand _command = default!;

    internal ResultRelationalDbQuery(SqlCommand? command)
        => _command = (command, command?.CommandText) is (null, null) ?
                        throw new ArgumentNullException("SQL-команда не создана") :
                        command;

    public async Task<int> GetNonQueryResultAsync()
    {
        int result = 0;

        await Task.Run(async () => result = await _command.ExecuteNonQueryAsync());

        return result;
    }

    public async Task<int> GetNonQueryResultAsync<TModel>(TModel model)
          where TModel : class, IModel, new()
    {
        int result = 0;

        await Task.Run(async () =>
        {
            if (model is UserModel user)
            {
                _command.Parameters.AddWithValue("@id", user.Id);
                _command.Parameters.AddWithValue("@first_name", user.FirstName);
                _command.Parameters.AddWithValue("@second_name", user.SecondName);
                _command.Parameters.AddWithValue("@patronymic", user.Patronymic);
                _command.Parameters.AddWithValue("@login", user.Login);
                _command.Parameters.AddWithValue("@password", user.Password);
                _command.Parameters.AddWithValue("@description", user.Description);
                _command.Parameters.AddWithValue("@role", user.Role);

                result = await _command.ExecuteNonQueryAsync();
            }
            else if (model is IProductModel product)
            {
                _command.Parameters.AddWithValue("@id", product.GetHashCode());
            }
        });

        return result;
    }

    public async Task<ConcurrentQueue<TModel>> GetReaderResultToArrayAsync<TModel>()
        where TModel : class, IModel, new()
    {
        ConcurrentQueue<TModel> result = new ConcurrentQueue<TModel>();
        TModel model = new TModel();

        await Task.Run(async () =>
        {
            await using SqlDataReader reader = await _command.ExecuteReaderAsync();

            if (result is IUserModel user)
            {
                while (await reader.ReadAsync())
                {
                    user.FirstName = reader["Name"].ToString();
                    user.Role = Convert.ToInt32(reader["Role"]);
                    user.Login = reader["Login"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.Description = reader["Description"].ToString();

                    result.Enqueue(user as TModel);
                }
            }
            else if (model is IProductModel product)
            {
                while (await reader.ReadAsync())
                {
                    product.Title = reader["name"]?.ToString();
                    product.Image = reader["appearance"].ToString();
                    product.Category = reader["category"]?.ToString();
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
                    user.Role = Convert.ToInt32(reader["role_id"]);
                    user.FirstName = reader["first_name"].ToString();
                    user.Login = reader["login"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Description = reader["description"].ToString();
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