using CourseWork2.ViewModel.Abstractions;

namespace CourseWork2.ViewModel;

public class AddWorkerViewModel : ViewModelBase
{
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
    
    
}