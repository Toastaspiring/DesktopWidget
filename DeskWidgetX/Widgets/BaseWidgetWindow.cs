using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;
using DeskWidgetX.Utils;

namespace DeskWidgetX.Widgets;

public class BaseWidgetWindow : Window
{
    public BaseWidgetWindow()
    {
        Width = 200;
        Height = 80;
        WindowStyle = WindowStyle.None;
        ResizeMode = ResizeMode.NoResize;
        AllowsTransparency = true;
        Background = System.Windows.Media.Brushes.Transparent;
        ShowInTaskbar = false;
        Loaded += BaseWidgetWindow_Loaded;
        MouseLeftButtonDown += BaseWidgetWindow_MouseLeftButtonDown;
    }

    private void BaseWidgetWindow_Loaded(object sender, RoutedEventArgs e)
    {
        Win32Interop.AttachToDesktop(this);
        Win32Interop.SetToolWindow(this);
        Win32Interop.SetClickThrough(this, App.Config.Widgets.ClickThrough);
    }

    private void BaseWidgetWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}
