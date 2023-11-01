using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.Internal.DataSet;
using DemoExam.UIDesign.SQLQueries;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class TableLayoutPanelPlaceHolder : IDisposable, IAsyncDisposable
{
    private ProductModel[] _products = default!;
    private readonly MainPanel _managementPanel = default!;

    internal TableLayoutPanelPlaceHolder()
        => _managementPanel = new MainPanel();

    internal async Task GetItemsAsync()
    {
        _products = await Databases
                        .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
                        .ExecuteReaderToArrayAsync<ProductModel>(SQLQuery.GetAllProducts());
    }

    internal void SetRowCountAndStyle(TableLayoutPanel panel)
    {
        panel.RowCount = 44 / 3;
        panel.ColumnStyles.Clear();
        panel.RowStyles.Clear();

        for (int index = 0; index < panel.RowCount; index++)
            panel.RowStyles.Add(new RowStyle() { Height = 50, SizeType = SizeType.Percent });
        for (int index = 0; index < panel.ColumnCount; index++)
            panel.ColumnStyles.Add(new ColumnStyle() { Width = 33, SizeType = SizeType.Percent });
    }

    internal async Task AddItemsAsync(TableLayoutPanel panel)
    {
        panel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        panel.Controls.AddRange(await _managementPanel.CreateAsync(_products));
    }

    ~TableLayoutPanelPlaceHolder()
        => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}