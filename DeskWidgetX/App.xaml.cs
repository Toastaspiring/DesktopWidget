using System.Windows;
using DeskWidgetX.Utils;
using DeskWidgetX.Widgets;

namespace DeskWidgetX;

public partial class App : Application
{
    public static Config Config { get; private set; } = new();

    private void App_Startup(object sender, StartupEventArgs e)
    {
        Config = ConfigLoader.Load();

        var cpu = new CPUWidget();
        cpu.Show();

        var ram = new RAMWidget();
        ram.Left = cpu.Left + 210;
        ram.Show();

        var spotify = new SpotifyWidget();
        spotify.Left = ram.Left + 210;
        spotify.Show();

        var lol = new LoLRankWidget();
        lol.Left = spotify.Left + 210;
        lol.Show();
    }
}
