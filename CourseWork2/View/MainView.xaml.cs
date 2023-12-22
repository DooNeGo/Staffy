using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Microsoft.Win32;

namespace CourseWork2.View;

public partial class MainView
{
    private readonly WindowInteropHelper _helper;

    public MainView()
    {
        InitializeComponent();

        _helper   = new WindowInteropHelper(this);
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        MaxWidth  = SystemParameters.MaximizedPrimaryScreenWidth;
        
        SystemEvents.DisplaySettingsChanging += OnDisplaySettingsChanging;
        Closed += OnClosed;
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        SystemEvents.DisplaySettingsChanging -= OnDisplaySettingsChanging;
    }

    private void OnDisplaySettingsChanging(object? sender, EventArgs e)
    {
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        MaxWidth  = SystemParameters.MaximizedPrimaryScreenWidth;
    }

#pragma warning disable SYSLIB1054
    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
#pragma warning restore SYSLIB1054

    private void ControlBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        SendMessage(_helper.Handle, 161, 2, 0);
    }

    private void CloseButton_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void MinimizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState is WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }
}