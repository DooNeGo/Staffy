using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class DepartmentRepository : RepositoryBase, IDepartmentRepository
{
    public Task Add(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public Task Edit(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public async Task Remove(int id)
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();

        Task task = connection.OpenAsync();

        command.CommandText = "DELETE FROM departments WHERE id=@id";
        command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)).Value = id;

        await task;
        command.ExecuteNonQuery();
        InvokeRepositoryChanged();
    }
    
    public async Task Remove(IEnumerable<int> id)
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();

        Task task = connection.OpenAsync();

        command.CommandText = "DELETE FROM departments WHERE id IN @id";
        command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)).Value = id;

        await task;
        command.ExecuteNonQuery();
        InvokeRepositoryChanged();
    }

    public async Task<IEnumerable<DepartmentModel>> GetAll()
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();

        Task task = connection.OpenAsync();

        command.CommandText = "SELECT * FROM departments";

        await                       task;
        await using MySqlDataReader reader = command.ExecuteReader();

        List<DepartmentModel> departmentModels = [];
        while (reader.Read())
        {
            departmentModels.Add(new DepartmentModel
            {
                Id = (int)reader[0],
                Name = reader[1].ToString()!,
                Address = reader[2].ToString()!,
                Phone = reader[3].ToString()!
            });
        }

        return departmentModels;
    }
}