using DemoExam.ModelClasses.Product;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager.ChildControlsBuilder;

internal class BottomPanelBuilder
{
    private readonly RightPanelBuilder _rightPanelBuilder = default!;

    internal BottomPanelBuilder()
        => _rightPanelBuilder = new RightPanelBuilder();

    internal Panel Create(ProductModel product)
    {
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

        bottomPanel.Controls.Add(_rightPanelBuilder.Create(product));

        return bottomPanel;
    }
}