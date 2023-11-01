namespace DemoExam.ModelClasses.Product;

public class ProductModel : IProductModel
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}