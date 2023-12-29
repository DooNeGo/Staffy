using System.Windows.Controls;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.View;
using CourseWork2.ViewModel.Abstractions;

namespace CourseWork2.ViewModel;

public class WorkersViewModel : IntegratedViewModel<WorkerRepository, WorkerModel>
{
    private UserControl _addWorkerView;
    private UserControl _mainView;
    private UserControl _currentView;
    
    public WorkersViewModel()
    {
        _addWorkerView    = new AddWorkerView();
        ShowAddWorkerView = new ViewModelCommand(ExecuteShowAddWorkerView);
        _currentView      = _mainView;
    }

    public ICommand ShowAddWorkerView { get; }

    public UserControl CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value ?? throw new ArgumentNullException(nameof(value));
            InvokePropertyChanged(nameof(CurrentView));
        }
    }

    private void ExecuteShowAddWorkerView(object? obj)
    {
        throw new NotImplementedException();
    }
}