using System.Windows.Controls;
using System.Windows.Media;

namespace CourseWork2.View;

public partial class DepartmentsView
{
    public DepartmentsView()
    {
        InitializeComponent();
    }

    private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!sender.Equals(SearchBox))
        {
            return;
        }

        if (string.IsNullOrEmpty(SearchBox.Text))
        {
            SearchBox.Background = (ImageBrush)FindResource("Watermark");
        }
        else
        {
            SearchBox.Background = null;
        }
    }
}