using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.FormWithGoods.ControlManager;
using DemoExam.UIDesign.FormWithGoods.ControlManager.EventsControl;
using DemoExam.UIDesign.FormWithGoods.Internal;
using DemoExam.UIDesign.FormWithGoods.Internal.ControlsExtensions;
using DemoExam.UIDesign.FormWithGoods.Internal.DataSet;

namespace DemoExam.UIDesign;

public partial class ProductForm : Form
{
    public ProductForm(UserModel user)
    {
        InitializeComponent();
        ManagerFacade.User = user;
        ManagerFacade.Controls = new Controls(BasketListBox, SearchTextBox, this, ProductsViewTable);
    }

    private async void ProductForm_Load(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            ProductsViewTable.ThreadSafeAddition(async () =>
            {
                await using TableLayoutPanelPlaceHolder panel = new TableLayoutPanelPlaceHolder();
                await panel.AddItemsAsync(ProductsViewTable);
            });
        });
    }

    internal void Search(object sender, EventArgs e)
    {
        Control needControl = ProductsViewTable.Controls.Find($"MainPanel{SearchTextBox.Text}", true).First();

        int desiredRow = ProductsViewTable.GetRow(needControl);

        if (desiredRow < 0)
            MessageBox.Show("Товар не найден");
        else
            ProductsViewTable.ScrollControlIntoView(ProductsViewTable.GetControlFromPosition(0, desiredRow));

    }
}