using System.Windows.Controls;
using System.Windows.Input;
using CourseWork2.Model;
using CourseWork2.Repositories;
using CourseWork2.View;
using CourseWork2.ViewModel.Abstractions;

namespace CourseWork2.ViewModel;

public class WorkersViewModel : IntegratedViewModel<WorkerRepository, WorkerModel>
{
    private readonly UserControl _addWorkerView;

    private UserControl _currentView;
    
    public WorkersViewModel()
    {
        _addWorkerView    = new AddWorkerView();
        DataGridView      = new DataGridWorkersView();
        ShowAddWorkerView = new ViewModelCommand(ExecuteShowAddWorkerView);
        _currentView      = DataGridView;

        DataGridView.DataContext = this;

        ((AddWorkerViewModel)_addWorkerView.DataContext).BackButtonClick += () =>
        {
            CurrentView = DataGridView;
        };
    }

    public UserControl DataGridView { get; }

    public ICommand ShowAddWorkerView { get; }

    public UserControl CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    private void ExecuteShowAddWorkerView(object? obj)
    {
        CurrentView = _addWorkerView;
    }
}