namespace DemoExam.UIDesign.FormWithGoods.Internal.ControlsExtensions;

internal static class ControlExtension
{
    private static readonly ToolTip _toolTip = new ToolTip();

    internal static TControl SetToolTip<TControl>(this TControl control, string caption)
        where TControl : Control
    {
        _toolTip.SetToolTip(control, caption);

        return control;
    }

    internal static void ThreadSafeAddition<TControl>(this TControl control, Action action)
        where TControl : Control
    {
        if (control.InvokeRequired)
            control.BeginInvoke(action);
        else
            action();
    }
}