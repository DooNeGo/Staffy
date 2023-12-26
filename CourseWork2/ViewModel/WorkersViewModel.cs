using CourseWork2.Model;
using CourseWork2.Repositories;

namespace CourseWork2.ViewModel;

public class WorkersViewModel : IntegratedViewModel<WorkerRepository, WorkerModel>
{
    protected override void UpdateItems()
    {
        base.UpdateItems();
        //TODO: добавить еще поиск по department id
    }
}