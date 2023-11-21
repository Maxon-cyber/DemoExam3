using AccessingDatabase.Internal.DatabaseManagement.RelationalDb.Databases;
using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.SQLQueries;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class TableLayoutPanelPlaceHolder : IDisposable, IAsyncDisposable
{
    internal TableLayoutPanelPlaceHolder() { }

    internal async Task AddItemsAsync(TableLayoutPanel panel)
    {
        panel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        await using MSSQLDatabase<ProductModel> database = new MSSQLDatabase<ProductModel>();
        await using ParentPanel parentPanel = new ParentPanel();

        ProductModel[] products = await database.ExecuteReaderToArrayAsync(SQLQuery.GetAllProducts());
        Panel[] panels = await parentPanel.CreateAsync(products);

        panel.SuspendLayout();
        foreach (int index in ParallelEnumerable.Range(0, panels.Length))
        {
            panel.SetCellPosition(panels[index], new TableLayoutPanelCellPosition());
            panel.Controls.Add(panels[index]);
        }
        panel.ResumeLayout();

        panel.RowCount = 45 / 3;
        panel.ColumnStyles.Clear();
        panel.RowStyles.Clear();

        for (int index = 0; index < panel.RowCount; index++)
            panel.RowStyles.Add(new RowStyle() { Height = 50, SizeType = SizeType.Percent });
        for (int index = 0; index < panel.ColumnCount; index++)
            panel.ColumnStyles.Add(new ColumnStyle() { Width = 33, SizeType = SizeType.Percent });
    }

    ~TableLayoutPanelPlaceHolder()
        => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}