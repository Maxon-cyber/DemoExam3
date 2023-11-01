using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.ControlManager.ChildControlsBuilder;
using DemoExam.UIDesign.FormWithGoods.Internal.ToolTipExtension;
using System.Linq.Expressions;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class MainPanelBuilder //: IDisposable, IAsyncDisposable
{
    private readonly BottomPanelBuilder _childPanelBuilder = default!;

    internal MainPanelBuilder()
        => _childPanelBuilder = new BottomPanelBuilder();

    internal PictureBox CreatePictureBox(ProductModel product)
        => new PictureBox()
        {
            Name = product.Title + "PictureBox",
            Size = new Size(278, 76),
            Location = new Point(0, 0),
            Image = Image.FromFile(@"C:\\Users\\рс\\Desktop\\для DemoExam1.jpg"),
            SizeMode = PictureBoxSizeMode.StretchImage,
        }.SetToolTip($"{product.Price}\n{product.Description}\n{product.Category}");

    internal Panel CreateChildPanel(ProductModel product)
        => _childPanelBuilder.Create(product);
}