using CourseWork2.Model;

namespace CourseWork2.ViewModel;

public class MainViewModel : ViewModelBase
{
    private readonly IUserRepository _userRepository;

    private UserModel        _currentUser;
    private UserAccountModel _currentUserAccount;

    public MainViewModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        LoadCurrentUserModel();
    }

    public UserAccountModel CurrentUserAccount
    {
        get => _currentUserAccount;
        set
        {
            _currentUserAccount = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(_currentUserAccount));
        }
    }

    private async void LoadCurrentUserModel()
    {
        _currentUser = await _userRepository.GetByUsername(Thread.CurrentPrincipal!.Identity!.Name!);
        CurrentUserAccount = new UserAccountModel
        {
            Username       = _currentUser.Username,
            ProfilePicture = null
        };
    }
}