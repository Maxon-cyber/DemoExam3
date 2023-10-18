using DemoExam.ModelClasses.User;
using DemoExam.UIDesign.FormWithGoods;

namespace DemoExam.UIDesign;

public partial class ProductForm : Form
{
    private readonly ManagementTableLayoutPanel _panel = default!;

    public ProductForm(UserModel user)
    {
        InitializeComponent();
        //_panel = new managementtablelayoutpanel(user);
        //_panel.setrowandcolumn(ref tablelayoutpanel1, tablelayoutpanel1.columncount);
        //_panel.AddItems(ref tableLayoutPanel1);
    }

    private void AddBtn_Click(object sneder, EventArgs e)
        => ManagementProductForm.AddItemToBasket(null, null);

    private void DeleteBtn_Click(object sender, EventArgs e)
        => ManagementProductForm.DeleteItemFromBasket();

    private void OrderBtn_Click(object sender, EventArgs e)
        => ManagementProductForm.Order();

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void ProductForm_Load(object sender, EventArgs e)
    {

    }
}