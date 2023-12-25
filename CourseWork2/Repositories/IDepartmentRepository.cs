using CourseWork2.Model;

namespace CourseWork2.Repositories;

public interface IDepartmentRepository
{
    public Task Add(DepartmentModel department);

    public Task Edit(DepartmentModel department);

    public Task Remove(int id);
    
    public Task<IEnumerable<DepartmentModel>> GetAll();
}