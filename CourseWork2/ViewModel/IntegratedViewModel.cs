using System.Windows.Forms;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.ViewModel.Abstractions;
using Timer = System.Timers.Timer;

namespace CourseWork2.ViewModel;

public class IntegratedViewModel<TRepository, TDataModel> : IntegratedViewModelBase
    where TRepository : RepositoryBase<TDataModel>, new()
    where TDataModel : IDataModel, new()
{
    private readonly TRepository _repository;
    private readonly Timer       _timer;

    private IEnumerable<TDataModel>? _items;
    private string?                  _searchText;
    private TDataModel?              _selectedItem;

    public IntegratedViewModel()
    {
        _repository   = new TRepository();
        DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        _timer        = new Timer { AutoReset = false };
        
        _repository.RepositoryChanged += UpdateItems;
        _timer.Elapsed                += (_, _) => { UpdateItems(); };
    }

    public ICommand DeleteCommand { get; }

    public string? SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            InvokePropertyChanged(nameof(SearchText));
            _timer.Interval = 500;
            _timer.Start();
        }
    }

    public TDataModel? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            InvokePropertyChanged(nameof(SelectedItem));
        }
    }

    public IEnumerable<TDataModel>? Items
    {
        get => _items;
        set
        {
            _items = value;
            InvokePropertyChanged(nameof(Items));
        }
    }

    public override void Load()
    {
        UpdateItems();
    }

    private async void UpdateItems()
    {
        Items = string.IsNullOrEmpty(SearchText)
            ? await _repository.GetAllAsync()
            : await _repository.GetAllByStringAsync(SearchText);
    }

    private bool CanExecuteDeleteCommand(object? obj)
    {
        return SelectedItem is not null;
    }

    private void ExecuteDeleteCommand(object? obj)
    {
        if (SelectedItem is null)
        {
            return;
        }


        if (MessageBox.Show("Are you sure?", "Confirmation of deletion", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) is DialogResult.Yes)
        {
            _repository.RemoveAsync(SelectedItem.Id);
        }
    }
}