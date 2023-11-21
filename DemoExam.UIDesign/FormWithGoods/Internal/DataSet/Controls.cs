namespace DemoExam.UIDesign.FormWithGoods.Internal.DataSet;

internal class Controls
{
    internal ListBox Basket { get; private set; }
    internal ProductForm ProductForm { get; private set; }
    internal TextBox SearchTextBox { get; private set; }
    internal TableLayoutPanel TableLayoutPanel { get; private set; }

    internal Controls(ListBox basket, TextBox searchTextBox,ProductForm productForm, TableLayoutPanel tableLayoutPanel)
    {
        Basket = basket;
        SearchTextBox = searchTextBox;
        ProductForm = productForm;
        TableLayoutPanel = tableLayoutPanel;
    }
}