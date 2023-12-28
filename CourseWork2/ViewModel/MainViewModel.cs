using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Windows.Controls;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.View;
using CourseWork2.ViewModel.Abstractions;
using FontAwesome.Sharp;

namespace CourseWork2.ViewModel;

public class MainViewModel : ViewModelBase
{
    private readonly UserRepository                   _userRepository;
    private readonly FrozenDictionary<Type, ViewData> _viewsData;

    private string           _caption;
    private UserControl      _currentChildView;
    private UserModel        _currentUser;
    private UserAccountModel _currentUserAccount;
    private IconChar         _icon;

    public MainViewModel()
    {
        _userRepository     = new UserRepository();
        _currentUserAccount = new UserAccountModel();

        ShowHomeViewCommand            = new ViewModelCommand(ExecuteShowHomeViewCommand);
        ShowDepartmentsViewCommand     = new ViewModelCommand(ExecuteShowDepartmentsViewCommand);
        ShowWorkersViewCommand         = new ViewModelCommand(ExecuteShowWorkersViewCommand);
        ShowPositionsViewCommand       = new ViewModelCommand(ExecuteShowPositionsViewCommand);
        ShowAcceptedWorkersViewCommand = new ViewModelCommand(ExecuteShowAcceptedWorkersCommand);
        ShowFiredWorkersViewCommand    = new ViewModelCommand(ExecuteShowFiredWorkersCommand);
        ShowRetiredWorkersViewCommand  = new ViewModelCommand(ExecuteShowRetiredWorkersCommand);

        var viewsData = new Dictionary<Type, ViewData>
        {
            { typeof(HomeView), new ViewData(new HomeView(), "Dashboard", IconChar.Home) },
            { typeof(DepartmentsView), new ViewData(new DepartmentsView(), "Departments", IconChar.Building) },
            { typeof(WorkersView), new ViewData(new WorkersView(), "Workers", IconChar.Users) },
            { typeof(PositionsView), new ViewData(new PositionsView(), "Positions", IconChar.Star) },
            { typeof(AcceptedWorkersView), new ViewData(new AcceptedWorkersView(), "Accepted Workers", IconChar.UserPlus) },
            { typeof(FiredWorkersView), new ViewData(new FiredWorkersView(), "Fired Workers", IconChar.UserSlash) },
            { typeof(RetiredWorkersView), new ViewData(new RetiredWorkersView(), "Retired Workers", IconChar.UserMinus) }
        };

        _viewsData = viewsData.ToFrozenDictionary();
        
        LoadCurrentUserModel();
        LoadViewModelsData();
        ExecuteShowDepartmentsViewCommand(null);
    }

    public ICommand ShowHomeViewCommand { get; }

    public ICommand ShowDepartmentsViewCommand { get; }

    public ICommand ShowWorkersViewCommand { get; }

    public ICommand ShowPositionsViewCommand { get; }
    
    public ICommand ShowAcceptedWorkersViewCommand { get; }
    
    public ICommand ShowFiredWorkersViewCommand { get; }
    
    public ICommand ShowRetiredWorkersViewCommand { get; }

    public UserAccountModel CurrentUserAccount
    {
        get => _currentUserAccount;
        set
        {
            _currentUserAccount = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(CurrentUserAccount));
        }
    }

    public UserControl CurrentChildView
    {
        get => _currentChildView;
        set
        {
            _currentChildView = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(CurrentChildView));
        }
    }

    public string Caption
    {
        get => _caption;
        set
        {
            _caption = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Caption));
        }
    }

    public IconChar Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            InvokePropertyChanged(nameof(Icon));
        }
    }

    public async void LoadCurrentUserModel()
    {
        _currentUser = await _userRepository.GetByUsernameAsync(Thread.CurrentPrincipal!.Identity!.Name!)
                       ?? throw new NullReferenceException("No such username in repository");
        CurrentUserAccount = new UserAccountModel
        {
            Username       = _currentUser.Username,
            ProfilePicture = null
        };
    }

    public void LoadViewModelsData()
    {
        ImmutableArray<ViewData> viewDataValues = _viewsData.Values;

        for (var i = 0; i < _viewsData.Count; i++)
        {
            ((IntegratedViewModelBase)viewDataValues[i].View.DataContext).Load();
        }
    }

    private void SetChildViewModelData(ViewData viewData)
    {
        CurrentChildView = viewData.View;
        Caption          = viewData.Caption;
        Icon             = viewData.Icon;
    }

    private void ExecuteShowHomeViewCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(HomeView)]);
    }

    private void ExecuteShowDepartmentsViewCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(DepartmentsView)]);
    }

    private void ExecuteShowWorkersViewCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(WorkersView)]);
    }

    private void ExecuteShowPositionsViewCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(PositionsView)]);
    }
    
    private void ExecuteShowAcceptedWorkersCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(AcceptedWorkersView)]);
    }
    
    private void ExecuteShowFiredWorkersCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(FiredWorkersView)]);
    }
    
    private void ExecuteShowRetiredWorkersCommand(object? obj)
    {
        SetChildViewModelData(_viewsData[typeof(RetiredWorkersView)]);
    }

    private class ViewData(UserControl view, string caption, IconChar icon)
    {
        public UserControl View { get; } = view;

        public string Caption { get; } = caption;

        public IconChar Icon { get; } = icon;
    }
}