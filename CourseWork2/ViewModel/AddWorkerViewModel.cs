using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.ViewModel.Abstractions;

namespace CourseWork2.ViewModel;

public class AddWorkerViewModel : ViewModelBase
{
    public event Action? BackButtonClick;
    
    private readonly WorkerRepository     _workerRepository     = new();
    private readonly DepartmentRepository _departmentRepository = new();
    
    private string _surname    = string.Empty;
    private string _name       = string.Empty;
    private string _patronymic = string.Empty;
    private string _gender     = string.Empty;
    private string _status     = string.Empty;
    private bool   _militaryRegistration;
    private string _department = string.Empty;

    private string? _surnameError;
    private string? _nameError;
    private string? _patronymicError;
    private string? _genderError;
    private string? _statusError;
    private string? _militaryRegistrationError;
    private string? _departmentError;

    private readonly string[] _statuses;
    private readonly string[] _genders;

    public AddWorkerViewModel()
    {
        AddWorkerCommand       = new ViewModelCommand(ExecuteAddWorkerCommand, CanExecuteAddWorkerCommand);
        BackButtonClickCommand = new ViewModelCommand(ExecuteBackButtonClickCommand);
        _statuses              = ["Accepted", "Fired", "Retired"];
        _genders               = ["Male", "Female"];
    }

    public ICommand AddWorkerCommand { get; }
    
    public ICommand BackButtonClickCommand { get; }
    
    #region Propperties
    
    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Surname));
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Name));
        }
    }

    public string Patronymic
    {
        get => _patronymic;
        set
        {
            _patronymic = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Patronymic));
        }
    }

    public string Gender
    {
        get => _gender;
        set
        {
            _gender = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Gender));
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Status));
        }
    }

    public bool MilitaryRegistration
    {
        get => _militaryRegistration;
        set
        {
            _militaryRegistration = value;
            InvokePropertyChanged(nameof(MilitaryRegistration));
        }
    }

    public string Department
    {
        get => _department;
        set
        {
            _department = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? SurnameError
    {
        get => _surnameError;
        set
        {
            _surnameError = value;
            InvokePropertyChanged(nameof(SurnameError));
        }
    }

    public string? NameError
    {
        get => _nameError;
        set
        {
            _nameError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? PatronymicError
    {
        get => _patronymicError;
        set
        {
            _patronymicError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? GenderError
    {
        get => _genderError;
        set
        {
            _genderError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? StatusError
    {
        get => _statusError;
        set
        {
            _statusError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? MilitaryRegistrationError
    {
        get => _militaryRegistrationError;
        set
        {
            _militaryRegistrationError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }

    public string? DepartmentError
    {
        get => _departmentError;
        set
        {
            _departmentError = value;
            InvokePropertyChanged(nameof(Department));
        }
    }
    
    #endregion

    private bool IsValidSurname()
    {
        return !string.IsNullOrEmpty(Surname) &&
               Surname.Length >= 2;
    }
    
    private bool IsValidName()
    {
        return !string.IsNullOrEmpty(Name) &&
               Name.Length >= 2;
    }
    
    private bool IsValidPatronymic()
    {
        return !string.IsNullOrEmpty(Patronymic) &&
               Patronymic.Length >= 2;
    }
    
    private bool IsValidGender()
    {
        return !string.IsNullOrEmpty(Gender) &&
               _genders.Contains(Gender);
    }
    
    private bool IsValidStatus()
    {
        return !string.IsNullOrEmpty(Status) &&
               _statuses.Contains(Status);
    }
    
    private bool IsValidDepartment()
    {
        return !string.IsNullOrEmpty(Department) &&
               _departmentRepository.GetByNameAsync(Department).GetAwaiter().GetResult() is not null;
    }
    
    private bool CanExecuteAddWorkerCommand(object? obj)
    {
        return IsValidSurname()    &&
               IsValidName()       &&
               IsValidPatronymic() &&
               IsValidGender()     &&
               IsValidStatus()     &&
               IsValidDepartment();
    }

    private async void ExecuteAddWorkerCommand(object? obj)
    {
        var worker = new WorkerModel
        {
            Surname = Surname,
            Name = Name,
            Patronymic = Patronymic,
            Gender = Gender,
            Status = Status,
            MilitaryRegistration = MilitaryRegistration,
            Department = (await _departmentRepository.GetByNameAsync(Department))!
        };
        _workerRepository.AddAsync(worker);
    }
    
    private void ExecuteBackButtonClickCommand(object? obj)
    {
        BackButtonClick?.Invoke();
    }
}