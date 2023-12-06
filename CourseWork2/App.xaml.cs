using CourseWork2.View;
using System.Windows;

namespace CourseWork2
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Window loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (!loginView.IsVisible && !loginView.IsEnabled)
                {
                    Window mainView = new MainView();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }
}
