using Azure.Messaging;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace CourseWork2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=MyDB;UID=root;PASSWORD=;";
            SqlConnection connection = new(connectionString);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("123");
        }
    }
}
