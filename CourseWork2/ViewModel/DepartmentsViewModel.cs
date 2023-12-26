using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;

namespace CourseWork2.ViewModel;

public class DepartmentsViewModel : IntegratedViewModelBase
{
    private readonly DepartmentRepository _repository;
    
    private DepartmentModel?              _selectedItem;
    private IEnumerable<DepartmentModel>? _items;

    public DepartmentsViewModel()
    {
        _repository    = new DepartmentRepository();
        DeleteCommand  = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        
        _repository.RepositoryChanged += UpdateItems;
    }
    
    public ICommand DeleteCommand { get; }
    
    public DepartmentModel? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(SelectedItem));
        }
    }

    public IEnumerable<DepartmentModel>? Items
    {
        get => _items;
        set
        {
            _items = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Items));
        }
    }
    
    public override void Load()
    {
        UpdateItems();
    }

    private async void UpdateItems()
    {
        Items = await _repository.GetAllAsync();
    }

    private bool CanExecuteDeleteCommand(object obj)
    {
        return SelectedItem is not null;
    }

    private void ExecuteDeleteCommand(object obj)
    {
        _repository.RemoveAsync(SelectedItem!);
    }
}