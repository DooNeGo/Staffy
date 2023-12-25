using System.Collections.ObjectModel;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;

namespace CourseWork2.ViewModel;

public class DepartmentsViewModel : ViewModelBase
{
    private readonly DepartmentRepository _repository;
    
    private List<DepartmentModel>        _selectedItems;
    private IEnumerable<DepartmentModel> _items;

    public DepartmentsViewModel()
    {
        _repository    = new DepartmentRepository();
        DeleteCommand  = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        _selectedItems = [];
        _items = new List<DepartmentModel>
        {
            new() { Id = 1, Address = "Home 101 22", Name = "Sales1", Phone = "+375447452007" },
            new() { Id = 2, Address = "Home 101 22", Name = "Sales2", Phone = "+375447452007" },
            new() { Id = 3, Address = "Home 101 22", Name = "Sales3", Phone = "+375447452007" },
            new() { Id = 4, Address = "Home 101 22", Name = "Sales4", Phone = "+375447452007" },
            new() { Id = 5, Address = "Home 101 22", Name = "Sales5", Phone = "+375447452007" },
            new() { Id = 6, Address = "Home 101 22", Name = "Sales6", Phone = "+375447452007" },
            new() { Id = 7, Address = "Home 101 22", Name = "Sales7", Phone = "+375447452007" },
            new() { Id = 8, Address = "Home 101 22", Name = "Sales8", Phone = "+375447452007" },
            new() { Id = 9, Address = "Home 101 22", Name = "Sales9", Phone = "+375447452007" },
            new() { Id = 10, Address = "Home 101 22", Name = "Sales10", Phone = "+375447452007" },
            new() { Id = 11, Address = "Home 101 22", Name = "Sales11", Phone = "+375447452007" },
            new() { Id = 12, Address = "Home 101 22", Name = "Sales12", Phone = "+375447452007" },
            new() { Id = 13, Address = "Home 101 22", Name = "Sales13", Phone = "+375447452007" },
            new() { Id = 14, Address = "Home 101 22", Name = "Sales14", Phone = "+375447452007" },
            new() { Id = 15, Address = "Home 101 22", Name = "Sales15", Phone = "+375447452007" },
        };
    }
    
    public List<DepartmentModel> SelectedItems
    {
        get => _selectedItems;
        set
        {
            _selectedItems = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(SelectedItems));
        }
    }

    public IEnumerable<DepartmentModel> Items
    {
        get => _items;
        set
        {
            _items = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(Items));
        }
    }

    private bool CanExecuteDeleteCommand(object obj)
    {
        return SelectedItems.Count is not 0;
    }

    private void ExecuteDeleteCommand(object obj)
    {
        IEnumerable<int> ids = from item in SelectedItems
                               select item.Id;
        _repository.Remove(ids);
    }

    public ICommand DeleteCommand { get; }
}