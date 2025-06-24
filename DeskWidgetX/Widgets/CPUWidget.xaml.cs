using System.Diagnostics;
using System.Windows.Threading;

namespace DeskWidgetX.Widgets;

public partial class CPUWidget : BaseWidgetWindow
{
    private readonly PerformanceCounter _cpuCounter = new("Processor", "% Processor Time", "_Total");
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromSeconds(1) };

    public CPUWidget()
    {
        InitializeComponent();
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        try
        {
            var value = _cpuCounter.NextValue();
            ValueText.Text = $"{value:F0}%";
        }
        catch
        {
            ValueText.Text = "N/A";
        }
    }
}
