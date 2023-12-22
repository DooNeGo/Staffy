using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace CourseWork2.View;

/// <summary>
///     Логика взаимодействия для MainView.xaml
/// </summary>
public partial class MainView
{
    private readonly WindowInteropHelper _helper;

    public MainView()
    {
        InitializeComponent();
        _helper = new WindowInteropHelper(this);
    }
    
        [DllImport("user32.dll")]
#pragma warning disable SYSLIB1054
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
#pragma warning restore SYSLIB1054

private void ControlBar_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        SendMessage(_helper.Handle, 161, 2, 0);
    }

    private void ControlBar_OnMouseEnter(object sender, MouseEventArgs e)
    {
        MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    }
}