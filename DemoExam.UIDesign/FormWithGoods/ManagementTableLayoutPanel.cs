using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.Product;
using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.SQLQueries;

namespace DemoExam.UIDesign.FormWithGoods;

internal class ManagementTableLayoutPanel
{
    private readonly ProductModel[] _products = default!;
    private readonly ManagementPanel _managementPanel = new ManagementPanel();

    internal ManagementTableLayoutPanel(UserModel user)
    {
        _products = Databases
                        .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                        .ExecuteReaderArrayAsync<ProductModel>(SQLQuery.GetProducts(user.Login, user.Password))
                        .Result
                        .ToArray();
    }

    internal void SetRowAndColumn(ref TableLayoutPanel panel, int columnCount)
        => (panel.ColumnCount, panel.RowCount) = (columnCount, _products.Length % columnCount == 0 ?
            (_products.Length / columnCount) + (_products.Length % columnCount) :
            _products.Length / columnCount);

    internal void AddItems(ref TableLayoutPanel panel)
    {
        for (int index = 0; index < _products.Length; index++)
            panel.Controls.Add(_managementPanel.Create(_products.ToArray()));
    }
}