using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.ControlManager.EventsControl;
using DemoExam.UIDesign.FormWithGoods.Internal.ControlsExtensions;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager.ChildControlsBuilder;

internal class RightPanelBuilder : IDisposable, IAsyncDisposable
{
    internal RightPanelBuilder() { }

    internal async Task<Panel> Create(ProductModel product)
    {
        Panel rightPanel = new Panel()
        {
            Name = "ManagementBasketPanel",
            Size = new Size(164, 42),
            Location = new Point(135, 0),
            Dock = DockStyle.Right,
        };
        Button addButton = new Button()
        {
            Name = "AddProductButton",
            Text = "+",
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(114, 15),
            Size = new Size(23, 23),
        }.SetToolTip("Добавить товар в корзину");

        Button subButton = new Button()
        {
            Name = "SubProductButton",
            Text = "-",
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(15, 15),
            Size = new Size(23, 23),
        }.SetToolTip("Удалить товар из корзины");


        ButtonEventManager buttonEvent = new ButtonEventManager(product);
        addButton.Click += buttonEvent.AddItemToBasket!;
        subButton.Click += buttonEvent.DeleteItemFromBasket!;

        rightPanel.Controls.Add(addButton);
        rightPanel.Controls.Add(subButton);

        return rightPanel;
    }

    ~RightPanelBuilder()
       => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}