using System.Diagnostics;
using System.Windows.Threading;

namespace DeskWidgetX.Widgets;

public partial class RAMWidget : BaseWidgetWindow
{
    private readonly PerformanceCounter _ramCounter = new("Memory", "Committed Bytes");
    private readonly ulong _totalMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromSeconds(1) };

    public RAMWidget()
    {
        InitializeComponent();
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        try
        {
            var used = _ramCounter.NextValue();
            string text = $"{used / (1024 * 1024 * 1024):F1} GB / {_totalMemory / (1024 * 1024 * 1024):F1} GB";
            ValueText.Text = text;
        }
        catch
        {
            ValueText.Text = "N/A";
        }
    }
}
