using System.Windows;
using System.Windows.Input;

namespace CourseWork2.View;

/// <summary>
///     Логика взаимодействия для MainView.xaml
/// </summary>
public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
    }

    private void MainView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState is MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
}