using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class PositionRepository : RepositoryBase<PositionModel>
{
    public PositionRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT * FROM positions WHERE id=@id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand = new MySqlCommand("SELECT * FROM positions");

        GetAllByStringCommand = new MySqlCommand("SELECT * FROM positions WHERE @string = id "            +
                                                 "OR LOCATE(@string, name) > 0 OR LOCATE(name, @string) > 0 " +
                                                 "OR LOCATE(@string, salary) > 0 OR LOCATE(salary, @string) > 0");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand = new MySqlCommand("DELETE FROM positions WHERE id=@id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
}