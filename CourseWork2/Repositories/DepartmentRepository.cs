using CourseWork2.Model;
using CourseWork2.Repositories.Abstractions;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class DepartmentRepository : RepositoryBase<DepartmentModel>, IDepartmentRepository
{
    public DepartmentRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT * FROM departments WHERE id=@id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetByNameCommand = new MySqlCommand("SELECT * FROM departments WHERE name=@name");
        GetByNameCommand.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar));

        GetAllCommand = new MySqlCommand("SELECT * FROM departments");

        GetAllByStringCommand = new MySqlCommand("SELECT * FROM departments WHERE LOCATE(@string, name) > 0 " +
                                                 "OR LOCATE(@string, address) > 0 OR LOCATE(@string, phone) > 0");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand = new MySqlCommand("DELETE FROM departments WHERE id=@id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }

    private MySqlCommand GetByNameCommand { get; }

    public Task Add(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public Task Edit(DepartmentModel department)
    {
        throw new NotImplementedException();
    }

    public async Task<DepartmentModel?> GetByNameAsync(string name)
    {
        return await GetValueAsync(GetByNameCommand, [name]);
    }
}