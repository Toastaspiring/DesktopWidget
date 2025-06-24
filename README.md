# DesktopWidget

DesktopWidget is a small WPF application for Windows that shows information widgets right on your desktop. The windows are transparent and attach themselves to the desktop using Win32 APIs so they behave like part of the wallpaper.

## Widgets

The application currently includes four widgets:

- **CPUWidget** – Displays the current CPU usage percentage.
- **RAMWidget** – Shows how much memory is used versus the total installed memory.
- **SpotifyWidget** – Intended to show the currently playing song and provide playback controls. The code contains placeholders for real Spotify API calls and requires a refresh token.
- **LoLRankWidget** – Intended to display a League of Legends rank. It requires a Riot API key and summoner details, but the API call is currently a placeholder.

## Configuration

Settings are read from `DeskWidgetX/config.json` at startup. Fill in your API keys and tokens here before running. Example:

```json
{
  "Spotify": {
    "ClientId": "",
    "ClientSecret": "",
    "RefreshToken": ""
  },
  "Riot": {
    "ApiKey": "",
    "SummonerName": "",
    "Region": "na1"
  },
  "Widgets": {
    "ClickThrough": false
  }
}
```

Set `Widgets.ClickThrough` to `true` if you want the widgets to ignore mouse clicks. This is useful when you just want them to display information without obstructing other windows.

## How it works

`App.xaml.cs` is the entry point. On startup it loads the configuration using `ConfigLoader.Load()` and creates an instance of each widget window. Each widget derives from `BaseWidgetWindow`, which attaches the window to the desktop (`Progman`) and sets the tool window and click-through styles via functions in `Win32Interop`. The windows can be repositioned by dragging with the left mouse button.

Widgets update themselves on a timer—CPU and RAM every second, Spotify every few seconds, and the League of Legends widget every 30 minutes.

## Building and running

You need the .NET 8 SDK. From the `DeskWidgetX` directory you can run the application with:

```bash
cd DeskWidgetX
dotnet run
```

Alternatively open `DeskWidgetX.sln` in Visual Studio 2022 or later and build/run from there. Ensure `config.json` is populated with your credentials so the widgets can access the APIs they need.

