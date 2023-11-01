using DemoExam.ModelClasses.Product;
using System;

namespace DemoExam.UIDesign.FormWithGoods.ControlManager;

internal sealed class MainPanel : IDisposable, IAsyncDisposable
{
    private readonly MainPanelBuilder _mainPanelBuilder = default!;

    internal MainPanel() =>
        _mainPanelBuilder = new MainPanelBuilder();

    internal async Task<Panel[]> CreateAsync(ProductModel[] products)
    {
        Panel[] panels = new Panel[44];

        foreach (int panelIndex in Enumerable.Range(0, 44).AsParallel())
        {
            Panel panel = new Panel()
            {
                Name = "MainPanel" + products[0],
                Dock = DockStyle.Fill
            };

            await Task.Run(() =>
            {
                Action action = () =>
                {
                    panel.Controls.Add(_mainPanelBuilder.CreatePictureBox(products[0]));
                    panel.Controls.Add(_mainPanelBuilder.CreateChildPanel(products[0]));
                };

                if (panel.InvokeRequired)
                    panel.Invoke(action);
                else
                    action();
            });

            panels[panelIndex] = panel;
        }

        return panels;
    }

    ~MainPanel()
        => Dispose();

    public async ValueTask DisposeAsync()
        => GC.SuppressFinalize(this);

    public void Dispose()
        => GC.SuppressFinalize(this);
}