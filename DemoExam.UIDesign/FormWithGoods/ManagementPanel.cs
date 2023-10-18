using DemoExam.ModelClasses.Product;

namespace DemoExam.UIDesign.FormWithGoods;

internal sealed class ManagementPanel
{
    private const int PADDING = 3;

    private const string IMAGE_NAME = "ProductPictureBox";
    private const int PICTUREBOX_WIDTH = 0;
    private const int PICTUREBOX_HEIGHT = 1;

    private const string LABEL_NAME = "ProductLabel";
    private const int LABEL_WIDTH = 0;
    private const int LABEL_HEIGHT = 0;
    private const int COUNT_OF_LABELS_IN_PANEL = 4;

    internal Panel Create(ProductModel[] products)
    {
        Panel panel = new Panel() { Dock = DockStyle.Fill };

        for (int index = 0; index < products.Length; index++)
        {
            panel.Controls.Add(
                new PictureBox()
                {
                    Name = IMAGE_NAME + products[index].Title,
                    Image = Image.FromFile(products[index].Appearance),
                    Size = new Size(PICTUREBOX_WIDTH, PICTUREBOX_HEIGHT),
                    Padding = new Padding(PADDING)
                });
            for (int countOfLabels = 0; countOfLabels < COUNT_OF_LABELS_IN_PANEL; countOfLabels++)
            {
                panel.Controls.Add(
                    new Label()
                    {
                        Name = LABEL_NAME + products[index].Title,
                        Text = products[index].Title,
                        Size = new Size(LABEL_WIDTH, LABEL_HEIGHT),
                        Padding = new Padding(PADDING)
                    });
            }
        }

        return panel;
    }
}