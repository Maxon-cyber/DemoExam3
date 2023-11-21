using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.Internal;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager.EventsControl;

internal class ButtonEventManager
{
    private readonly ListBox _basket = default!;
    private readonly List<ProductModel> _goods = default!;
    private readonly ProductModel _product = default!;
    private string _addProductString = default!;

    internal ButtonEventManager() { }

    internal ButtonEventManager(ProductModel product)
    {
        _product = product;
        _goods = new List<ProductModel>();
        _addProductString = $"{product.Title}-{product.Price}";
        _basket = ManagerFacade.Controls.Basket;
    }

    internal void AddItemToBasket(object sender, EventArgs e)
    {
        ++_product.Count;
        if (_basket.Items.Contains(_addProductString))
        {
            _basket.Items.Remove(_addProductString);

            if (_addProductString.Contains('('))
                _addProductString = _addProductString.Remove(_addProductString.IndexOf('('));
            _addProductString = _addProductString.Insert(_addProductString.Length, $"({_product.Count})");
            _basket.Items.Add(_addProductString);
            _goods.Add(_product);
        }
        else
            _basket.Items.Add(_addProductString);
    }

    internal void DeleteItemFromBasket(object sender, EventArgs e)
    {
        if (_basket.Items.Contains(_addProductString))
        {
            if (--_product.Count == 0)
            {
                _basket.Items.Remove(_addProductString);
                _goods.Remove(_product);
                return;
            }
            _basket.Items.Remove(_addProductString);

            if (_addProductString.Contains('('))
            {
                _addProductString = _addProductString.Remove(_addProductString.IndexOf('('));
                _addProductString = _addProductString.Insert(_addProductString.Length, $"({_product.Count})");
            }
            _basket.Items.Add(_addProductString);
        }
        else
            _basket.Items.Remove(_addProductString);
    }

    internal async void OrderAsync(object sender, EventArgs e)
    {

    }

    internal void Search(object sender, EventArgs e)
    {
        TableLayoutPanel tableLayoutPanel = ManagerFacade.Controls.TableLayoutPanel;
        string productName = ManagerFacade.Controls.SearchTextBox.Text;
        Control needControl = tableLayoutPanel.Controls.Find($"MainPanel{productName}", true).First();

        int desiredRow = tableLayoutPanel.GetRow(needControl);

        if (desiredRow < 0)
            MessageBox.Show("Товар не найден");
        else
            tableLayoutPanel.ScrollControlIntoView(tableLayoutPanel.GetControlFromPosition(0, desiredRow));
           
    }
}