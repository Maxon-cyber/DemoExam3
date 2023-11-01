namespace DemoExam.ModelClasses.Product;

public interface IProductModel : IModel
{
    string Title { get; set; }
    string Image { get; set; }
    string Category { get; set; }
    decimal Price { get; set; }
}