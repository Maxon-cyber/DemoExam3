namespace DemoExam.UIDesign.SQLQueries;

internal static class SQLQuery
{
    internal static string GetUser(string name, string login, string password)
        => $"SELECT * FROM dbo.AllUsers WHERE Name = '{name}' AND Login = '{login}' AND Password = '{password}'";

    internal static string GetProducts(string login, string password)
       => $"SELECT * FROM dbo.AllProducts WHERE Login = {login} AND Password = {password}";

    internal static string GetAllProducts()
        => $"SELECT * FROM dbo.AllProducts";
}