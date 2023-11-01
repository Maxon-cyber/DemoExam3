namespace DemoExam.UIDesign.SQLQueries;

internal static class SQLQuery
{
    internal static string GetUser(string name, string login, string password)
        => $"SELECT * FROM dbo.Users WHERE first_name = '{name}' AND login = '{login}' AND password = '{password}'";

    internal static string GetProductsFromBusket(string login, string password)
        => $"SELECT * FROM dbo.Products WHERE login = '{login}' AND password = '{password}'";

    internal static string GetAllProducts()
        => $"SELECT * FROM dbo.Products";
}