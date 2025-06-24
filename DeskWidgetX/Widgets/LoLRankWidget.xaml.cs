using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Threading;

namespace DeskWidgetX.Widgets;

public partial class LoLRankWidget : BaseWidgetWindow
{
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMinutes(30) };
    private readonly HttpClient _http = new();

    public LoLRankWidget()
    {
        InitializeComponent();
        _timer.Tick += Timer_Tick;
        _timer.Start();
        Loaded += (_, _) => _ = UpdateAsync();
    }

    private async void Timer_Tick(object? sender, EventArgs e)
    {
        await UpdateAsync();
    }

    private async Task UpdateAsync()
    {
        if (string.IsNullOrEmpty(App.Config.Riot.ApiKey) || string.IsNullOrEmpty(App.Config.Riot.SummonerName))
        {
            ValueText.Text = "No API key";
            return;
        }

        try
        {
            // Placeholder for actual Riot API call to get rank
            ValueText.Text = "Gold IV - 50 LP";
        }
        catch
        {
            ValueText.Text = "Error";
        }
    }
}
