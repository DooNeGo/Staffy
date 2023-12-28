using CourseWork2.Model;

namespace CourseWork2.Repositories.Abstractions;

public interface IDepartmentRepository
{
    public Task Add(DepartmentModel department);

    public Task Edit(DepartmentModel department);

    public Task RemoveAsync(int id);

    public Task<DepartmentModel?> GetByIdAsync(int id);

    public Task<DepartmentModel?> GetByNameAsync(string name);

    public Task<List<DepartmentModel>> GetAllAsync();

    public Task<List<DepartmentModel>> GetAllByStringAsync(string text);
}