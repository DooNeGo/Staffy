using CourseWork2.Repositories;
using System.Security;
using System.Windows.Input;

namespace CourseWork2.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = string.Empty;
        private SecureString _password = new();
        private string _errorMessage = string.Empty;
        private bool _isViewVisible = true;

        private Task<bool>? _loginTask;

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                InvokePropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                InvokePropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                InvokePropertyChanged(nameof(ErrorMessage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                InvokePropertyChanged(nameof(IsViewVisible));
            }
        }

        public ICommand LoginCommand { get; }

        public ICommand RecoverPasswordCommand { get; }

        public ICommand ShowPasswordCommand { get; }

        public ICommand RememberPasswordCommand { get; }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username)
                && !string.IsNullOrWhiteSpace(Password.ToString())
                && Username.Length >= 3
                && Password.Length >= 3;
        }

        private void ExecuteLoginCommand(object obj)
        {
            if (_loginTask is null)
            {
                UserRepository repositiory = new();
                _loginTask = repositiory.AuthenticateUserAsync(new System.Net.NetworkCredential(Username, Password));
            }

            if (!_loginTask.IsCompletedSuccessfully
                || _loginTask.IsCompletedSuccessfully
                && _loginTask.Result is false)
            {
                ErrorMessage = "Wrong Login or Password";
            }
            else
            {

            }
        }

        private void ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }
    }
}
