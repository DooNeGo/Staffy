using System.Windows;
using CourseWork2.View;

namespace CourseWork2;

public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        Window loginView = new LoginView();
        loginView.Show();
        loginView.IsVisibleChanged += (s, ev) =>
        {
            if (loginView is not { IsVisible: false, IsEnabled: false })
                return;

            Window mainView = new MainView();
            mainView.Show();
            loginView.Close();
        };
    }
}