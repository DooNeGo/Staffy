using CourseWork2.Model;

namespace CourseWork2.Repositories.Abstractions;

public interface IWorkerRepository
{
    public Task Add(WorkerModel worker);

    public Task Edit(WorkerModel worker);

    public Task RemoveAsync(int id);

    public Task<WorkerModel?> GetByIdAsync(int id);

    public Task<IEnumerable<WorkerModel>> GetAllAsync();

    public Task<IEnumerable<WorkerModel>> GetAllByStringAsync(string text);
}