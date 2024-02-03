using System.Net;
using System.Security;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.ViewModel.Abstractions;

namespace CourseWork2.ViewModel;

public class LoginViewModel : ViewModelBase
{
    private readonly UserRepository _userRepository;

    private string       _errorMessage  = string.Empty;
    private bool         _isViewVisible = true;
    private SecureString _password      = new();
    private string       _username      = string.Empty;

    public LoginViewModel()
    {
        LoginCommand           = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        RecoverPasswordCommand = new ViewModelCommand(_ => ExecuteRecoverPasswordCommand("", ""));
        _userRepository        = new UserRepository();
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

    public event Action<UserModel>? LoginSuccess;

    private bool CanExecuteLoginCommand(object? obj)
    {
        return !string.IsNullOrWhiteSpace(Username)
               && Username.Length >= 3
               && Password.Length >= 3;
    }

    private async void ExecuteLoginCommand(object? obj)
    {
        UserModel? result = await _userRepository.AuthenticateUserAsync(new NetworkCredential(Username, Password));
        if (result is null)
        {
            ErrorMessage = "Invalid Username or Password";
        }
        else
        {
            LoginSuccess?.Invoke(result);
        }
    }

    private void ExecuteRecoverPasswordCommand(string username, string email)
    {
        throw new NotImplementedException();
    }
}