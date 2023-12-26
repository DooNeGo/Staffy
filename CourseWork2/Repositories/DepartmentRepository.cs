using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class DepartmentRepository : RepositoryBase, IDepartmentRepository
{
    public DepartmentRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT * FROM departments WHERE id=@id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
        
        GetByNameCommand = new MySqlCommand("SELECT * FROM departments WHERE name=@name");
        GetByNameCommand.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar));
        
        GetAllCommand = new MySqlCommand("SELECT * FROM departments");
        
        DeleteCommand = new MySqlCommand("DELETE FROM departments WHERE id=@id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
    
    private MySqlCommand GetByIdCommand { get; }
    
    private MySqlCommand GetByNameCommand { get; }
    
    private MySqlCommand GetAllCommand { get; }
    
    private MySqlCommand DeleteCommand { get; }
    
    public Task Add(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public Task Edit(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(DepartmentModel department)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        await ExecuteCommandAsync(DeleteCommand, connection, [department.Id]);
    }

    public async Task<DepartmentModel?> GetByIdAsync(int id)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        
        return await GetByIdInternalAsync(id, connection);
    }
    
    public async Task<List<DepartmentModel>> GetByIdsAsync(IEnumerable<int> ids)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();

        List<int> list  = ids.ToList();
        var       tasks = new Task<DepartmentModel?>[list.Count];

        for (var i = 0; i < list.Count; i++)
        {
            tasks[i] = GetByIdInternalAsync(list[i], connection);
        }

        Task.WaitAll(tasks);
        var departmentModels = new List<DepartmentModel>(list.Count);

        foreach (Task<DepartmentModel?> task in tasks)
        {
            if (task.Result is not null)
            {
                departmentModels.Add(task.Result);
            }
        }

        return departmentModels;
    }

    public async Task<DepartmentModel?> GetByNameAsync(string name)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        
        return await GetByNameInternalAsync(name, connection);
    }

    public async Task<IEnumerable<DepartmentModel>> GetAllAsync()
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        
        return await GetAllAsync<DepartmentModel>(GetAllCommand, connection, []);
    }
    
    private async Task<DepartmentModel?> GetByNameInternalAsync(string name, MySqlConnection connection)
    {
        return await GetValueAsync<DepartmentModel>(GetByNameCommand, connection, [name]);
    }
    
    private async Task<DepartmentModel?> GetByIdInternalAsync(int id, MySqlConnection connection)
    {
        return await GetValueAsync<DepartmentModel>(GetByIdCommand, connection, [id]);
    }
}