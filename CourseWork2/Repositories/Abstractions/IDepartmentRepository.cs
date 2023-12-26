using CourseWork2.Model;

namespace CourseWork2.Repositories.Abstractions;

public interface IDepartmentRepository
{
    public Task Add(DepartmentModel department);

    public Task Edit(DepartmentModel department);

    public Task RemoveAsync(int id);

    public Task<DepartmentModel?> GetByIdAsync(int id);

    public Task<List<DepartmentModel>> GetByIdsAsync(IEnumerable<int> ids);

    public Task<DepartmentModel?> GetByNameAsync(string name);
    
    public Task<IEnumerable<DepartmentModel>> GetAllAsync();

    public Task<IEnumerable<DepartmentModel>> GetAllByStringAsync(string text);
}