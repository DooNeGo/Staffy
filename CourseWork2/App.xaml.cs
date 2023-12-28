using System.Windows;
using CourseWork2.View;
using CourseWork2.ViewModel;

namespace CourseWork2;

public partial class App
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        
        var loginView      = new LoginView();
        var loginViewModel = (LoginViewModel)loginView.DataContext;
        
        loginViewModel.LoginSuccess += () =>
        {
            var mainView = new MainView();
            
            loginView.Close();
            mainView.Show();
        };

        loginView.Show();
    }
}