using DemoExam.ModelClasses.Product;
using DemoExam.UIDesign.FormWithGoods.Internal.ControlsExtensions;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class ParentPanel : IDisposable, IAsyncDisposable
{
    internal ParentPanel() { }

    internal async Task<Panel[]> CreateAsync(ProductModel[] products)
    {
        await using MainPanelBuilder mainPanelBuilder = new MainPanelBuilder();
        Panel[] panels = new Panel[45];

        await Task.Run(() =>
        {
            foreach (int indexPanel in ParallelEnumerable.Range(0, panels.Length))
            {
                Panel panel = new Panel()
                {
                    Name = "MainPanel" + products[0].Title,
                    Dock = DockStyle.Fill
                };

                PictureBox productPhoto = new PictureBox()
                {
                    Name = products[0].Title + "PictureBox",
                    Size = new Size(278, 76),
                    Location = new Point(0, 0),
                    Image = Image.FromFile(@"C:\\Users\\рс\\Desktop\\для DemoExam1.jpg"),
                    SizeMode = PictureBoxSizeMode.StretchImage
                }.SetToolTip($"{products[0].Price}\n{products[0].Description}\n{products[0].Category}");

                panel.ThreadSafeAddition(async () =>
                {
                    panel.Controls.Add(productPhoto);

                    panel.Controls.Add(new Panel()
                    {
                        Name = "NestedPanel",
                        Size = new Size(292, 49),
                        Location = new Point(0, 106),
                        Dock = DockStyle.Bottom,
                    });

                    panel.Controls.Add(await mainPanelBuilder.CreateChildPanel(products[0]));
                });

                panels[indexPanel] = panel;
            }
        });

        return panels;
    }

    ~ParentPanel()
        => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}