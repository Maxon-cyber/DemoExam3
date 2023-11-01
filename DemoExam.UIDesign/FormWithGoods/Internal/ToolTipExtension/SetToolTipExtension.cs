namespace DemoExam.UIDesign.FormWithGoods.Internal.ToolTipExtension;

internal static class SetToolTipExtension
{
    private static readonly ToolTip _toolTip = new ToolTip();

    internal static TControl SetToolTip<TControl>(this TControl control, string caption)
        where TControl : Control
    {
        _toolTip.SetToolTip(control, caption);

        return control;
    }
}