using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DeskWidgetX.Widgets;

public partial class SpotifyWidget : BaseWidgetWindow
{
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromSeconds(3) };
    private readonly HttpClient _http = new();

    public SpotifyWidget()
    {
        InitializeComponent();
        _timer.Tick += Timer_Tick;
        _timer.Start();
        PrevButton.Click += async (_, _) => await SendCommand("previous");
        PlayPauseButton.Click += async (_, _) => await SendCommand("play-pause");
        NextButton.Click += async (_, _) => await SendCommand("next");
    }

    private async void Timer_Tick(object? sender, EventArgs e)
    {
        var token = App.Config.Spotify.RefreshToken;
        if (string.IsNullOrEmpty(token))
        {
            SongText.Text = "No token";
            return;
        }
        try
        {
            // Placeholder: replace with real Spotify API call
            SongText.Text = "Song name";
            ArtistText.Text = "Artist";
            // Album art placeholder
        }
        catch
        {
            SongText.Text = "Error";
        }
    }

    private async Task SendCommand(string command)
    {
        // Placeholder for sending playback command to Spotify API
    }
}
