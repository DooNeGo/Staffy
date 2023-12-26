using System.Windows;
using CourseWork2.View;
using CourseWork2.ViewModel;

namespace CourseWork2;

public partial class App
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        var mainView      = new MainView();
        var mainViewModel = (MainViewModel)mainView.DataContext;

        var loginView      = new LoginView();
        var loginViewModel = (LoginViewModel)loginView.DataContext;

        loginViewModel.LoginSuccess += mainViewModel.LoadCurrentUserModel;
        loginViewModel.LoginSuccess += loginView.Close;
        loginViewModel.LoginSuccess += mainView.Show;
        loginViewModel.LoginSuccess += mainViewModel.LoadViewModelsData;

        loginView.Show();
    }
}