using AccessingDatabase;
using AccessingDatabase.EnumerationOfDatabases;
using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.Internal;
using DemoExam.UIDesign.SQLQueries;
using System.Data;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager.EventsControl;

internal class ButtonEventManager
{
    private readonly Label _counter = default!;
    private readonly List<ProductModel> _goods = new List<ProductModel>();
    private readonly ProductModel _product = default!;

    internal ButtonEventManager(ProductModel product, Label counter)
    {
        _counter = counter;
        _product = product;
    }

    internal void AddItemToBasket(object sender, EventArgs e)
    {
        _goods.Add(_product);
        ManagerFacade.Controls.Basket.Items.Add($"{_product.Title}-{_product.Price}");
    }

    internal void DeleteItemFromBasket(object sender, EventArgs e)
    {
        ManagerFacade.Controls.Basket.Items.Remove(ManagerFacade.Controls.Basket.SelectedItem);
    }

    internal async void OrderAsync(object sender, EventArgs e)
    {
        await Databases
            .SelectRelationalDatabase(CurrentRelationalDatabase.MSSQLDatabase)
            .ExecuteNonQueryAsync(
            StoredProcedure.InsertProduct,
            _goods.ToArray(),
            ManagerFacade.User.Id,
            CommandType.StoredProcedure
            );
    }

    internal void Search(object sender, EventArgs e)
    {
    }
}