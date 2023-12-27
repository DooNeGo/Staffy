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
        _timer.Start();

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
        if (SearchText is null)
        {
            Items = await _repository.GetAllAsync();
        }
        else
        {
            Items = await _repository.GetAllByStringAsync(SearchText);
            
            if (!int.TryParse(SearchText, out int result))
            {
                return;
            }

            TDataModel? item = await _repository.GetByIdAsync(result);
            if (item is not null)
            {
                Items = Items.Append(item);
            }
        }
    }

    private bool CanExecuteDeleteCommand(object obj)
    {
        return SelectedItem is not null;
    }

    private void ExecuteDeleteCommand(object obj)
    {
        _repository.RemoveAsync(SelectedItem!.Id);
    }
}