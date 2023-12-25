using System.Windows.Input;
using CourseWork2.ViewModel;

namespace CourseWork2.Model;

public class DepartmentModel
{
    public DepartmentModel()
    {
        DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
    }

    public int    Id      { get; set; }
    public string Name    { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone   { get; set; } = string.Empty;
    
    public ICommand DeleteCommand { get; }

    public event Action<DepartmentModel>? Delete;
    
    private void ExecuteDeleteCommand(object obj)
    {
        Delete?.Invoke(this);
    }
}