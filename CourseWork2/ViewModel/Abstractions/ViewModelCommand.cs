using System.Windows.Input;

namespace CourseWork2.ViewModel.Abstractions;

internal class ViewModelCommand(Action<object?> executeAction, Predicate<object?>? canExecuteAction = null)
    : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return canExecuteAction is null || canExecuteAction(parameter);
    }

    public void Execute(object? parameter)
    {
        executeAction.Invoke(parameter);
    }
}