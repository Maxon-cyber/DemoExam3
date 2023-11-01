using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.ControlManager.EventsControl;
using DemoExam.UIDesign.FormWithGoods.Internal.ToolTipExtension;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager.ChildControlsBuilder;

internal class RightPanelBuilder
{
    internal RightPanelBuilder() { }

    internal Panel Create(ProductModel product)
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

        Label counter = new Label()
        {
            Name = "" + product.Title,
            Text = "0",
            Size = new Size(30, 30),
            Location = new Point(56, 18),
        };

        Button subButton = new Button()
        {
            Name = "SubProductButton",
            Text = "-",
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(15, 15),
            Size = new Size(23, 23),
        }.SetToolTip("Удалить товар из корзины");


        ButtonEventManager buttonEvent = new ButtonEventManager(product, counter);
        addButton.Click += buttonEvent.AddItemToBasket!;
        subButton.Click += buttonEvent.DeleteItemFromBasket!;

        rightPanel.Controls.Add(counter);
        rightPanel.Controls.Add(addButton);
        rightPanel.Controls.Add(subButton);

        return rightPanel;
    }
}