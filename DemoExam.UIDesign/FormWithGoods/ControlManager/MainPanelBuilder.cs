using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.ControlManager.ChildControlsBuilder;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class MainPanelBuilder : IDisposable, IAsyncDisposable
{
    internal MainPanelBuilder() { }

    internal async Task<Panel> CreateChildPanel(ProductModel product)
    {
        await using RightPanelBuilder rightPanelBuilder = new RightPanelBuilder();
        Panel bottomPanel = new Panel()
        {
            Name = "NestedPanel",
            Size = new Size(292, 49),
            Location = new Point(0, 106),
            Dock = DockStyle.Bottom,
        };
        bottomPanel.Controls.Add(new Label()
        {
            Name = "NameProductLabel",
            Text = product.Title,
            Location = new Point(3, 18),
        });

        bottomPanel.Controls.Add(await rightPanelBuilder.Create(product));

        return bottomPanel;
    }

    ~MainPanelBuilder()
        => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}