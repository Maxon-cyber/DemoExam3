using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.FormWithGoods.ControlManager;
using DemoExam.UIDesign.FormWithGoods.Internal;
using DemoExam.UIDesign.FormWithGoods.Internal.DataSet;

namespace DemoExam.UIDesign;

public partial class ProductForm : Form
{
    public ProductForm(UserModel user)
    {
        InitializeComponent();
        ManagerFacade.User = user;
        ManagerFacade.Controls = new Controls(BasketListBox, this, tableLayoutPanel1);
    }

    private async void ProductForm_Load(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            Action action = async () =>
            {
                await using TableLayoutPanelPlaceHolder panel = new TableLayoutPanelPlaceHolder();
                await panel.GetItemsAsync();
                await panel.AddItemsAsync(tableLayoutPanel1);
                panel.SetRowCountAndStyle(tableLayoutPanel1);
            };

            if (InvokeRequired)
                Invoke(action);
            else
                action();
        });
    }
}