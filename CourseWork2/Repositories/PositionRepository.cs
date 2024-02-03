using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class PositionRepository : RepositoryBase<PositionModel>
{
    public PositionRepository()
    {
        GetByIdCommand.CommandText = "SELECT p.id, p.name, p.salary, d.name " +
                                     "FROM positions as p, departments as d " +
                                     "WHERE p.id = @id AND p.department_id = d.id";
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand.CommandText = "SELECT p.id, p.name, p.salary, d.name " +
                                    "FROM positions as p, departments as d " +
                                    "WHERE p.department_id = d.id";

        GetAllByStringCommand.CommandText = "SELECT p.id, p.name, p.salary, d.name "                              +
                                            "FROM positions as p, departments as d WHERE p.department_id = d.id " +
                                            "AND (LOCATE(@string, d.name) > 0 OR LOCATE(d.name, @string) > 0 "    +
                                            "OR LOCATE(@string, p.name) > 0 OR LOCATE(p.name, @string) > 0 "      +
                                            "OR salary = @string OR p.id = @string OR d.id = @string)";
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand.CommandText = "DELETE FROM positions WHERE id = @id";
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
}