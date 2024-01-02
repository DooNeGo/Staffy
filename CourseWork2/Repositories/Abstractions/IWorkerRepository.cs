using CourseWork2.Model;

namespace CourseWork2.Repositories.Abstractions;

public interface IWorkerRepository
{
    public Task AddAsync(WorkerModel worker);

    public Task EditAsync(WorkerModel worker);

    public Task RemoveAsync(int id);

    public Task<WorkerModel?> GetByIdAsync(int id);

    public Task<List<WorkerModel>> GetAllAsync();

    public Task<List<WorkerModel>> GetAllByStringAsync(string text);
}