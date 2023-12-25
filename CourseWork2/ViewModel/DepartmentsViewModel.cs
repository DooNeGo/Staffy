using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;

namespace CourseWork2.ViewModel;

public class DepartmentsViewModel : ViewModelBase
{
    private readonly DepartmentRepository _repository;
    
    private DepartmentModel?              _selectedItem;
    private IEnumerable<DepartmentModel>? _items;

    public DepartmentsViewModel()
    {
        _repository    = new DepartmentRepository();
        DeleteCommand  = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        
        _repository.RepositoryChanged += UpdateItems;
        UpdateItems();
    }
    
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

    private async void UpdateItems()
    {
        Items = await _repository.GetAll();
        foreach (DepartmentModel item in Items)
        {
            item.Delete += DeleteItem;
        }
    }

    private void DeleteItem(DepartmentModel item)
    {
        _repository.Remove(item.Id);
    }

    private bool CanExecuteDeleteCommand(object obj)
    {
        return SelectedItem is not null;
    }

    private void ExecuteDeleteCommand(object obj)
    {
        _repository.Remove(SelectedItem!.Id);
    }

    public ICommand DeleteCommand { get; }
}