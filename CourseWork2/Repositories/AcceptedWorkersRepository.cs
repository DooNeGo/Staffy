using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class AcceptedWorkersRepository : RepositoryBase<AcceptedWorkerModel>
{
    public AcceptedWorkersRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT a.id, w.surname, w.name, w.patronymic, p.name, " +
                                          "DATE_FORMAT(a.accept_date, '%d/%m/%Y'), actual_salary " +
                                          "FROM accepted_workers as a, workers as w, positions as p " +
                                          "WHERE a.id=@id AND w.id = a.worker_id AND p.id = a.position_id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand = new MySqlCommand("SELECT a.id, w.surname, w.name, w.patronymic, p.name, " +
                                         "DATE_FORMAT(a.accept_date, '%d/%m/%Y'), actual_salary " +
                                         "FROM accepted_workers as a, workers as w, positions as p " +
                                         "WHERE w.id = a.worker_id AND p.id = a.position_id");

        GetAllByStringCommand = new MySqlCommand(
            "SELECT a.id, w.surname, w.name, w.patronymic, p.name, DATE_FORMAT(a.accept_date, '%d/%m/%Y')," +
            "actual_salary FROM accepted_workers as a " +
            "INNER JOIN workers as w ON w.id = a.worker_id " +
            "INNER JOIN positions as p ON p.id = a.position_id " +
            "WHERE (@string = a.id OR @string = w.id OR @string = p.id " +
                "OR w.surname LIKE CONCAT('%', @string, '%') OR w.name LIKE CONCAT('%', @string, '%') " +
                "OR w.patronymic LIKE CONCAT('%', @string, '%') OR p.name LIKE CONCAT('%', @string, '%') " +
                "OR YEAR(a.accept_date) = @string OR MONTH(a.accept_date) = @string " +
                "OR DAY(a.accept_date) = @string OR a.actual_salary = @string)");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand = new MySqlCommand("DELETE FROM accepted_workers WHERE id = @id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
}