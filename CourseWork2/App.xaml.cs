using System.Windows;
using CourseWork2.View;
using CourseWork2.ViewModel;

namespace CourseWork2;

public partial class App : Application
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        var mainView       = new MainView();
        var loginView      = new LoginView();
        var loginViewModel = (LoginViewModel)loginView.DataContext;

        loginViewModel.LoginSuccess += () =>
        {
            loginView.Close();
            mainView.Show();
        };

        loginView.Show();
    }
}