using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class AcceptedWorkersRepository : RepositoryBase<AcceptedWorkerModel>
{
    public AcceptedWorkersRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT a.id, w.surname, w.name, w.patronymic, p.name, "    +
                                          "DATE_FORMAT(a.accept_date, '%d/%m/%Y'), actual_salary "    +
                                          "FROM accepted_workers as a, workers as w, positions as p " +
                                          "WHERE a.id=@id AND w.id = a.worker_id AND p.id = a.position_id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand = new MySqlCommand("SELECT a.id, w.surname, w.name, w.patronymic, p.name, "    +
                                         "DATE_FORMAT(a.accept_date, '%d/%m/%Y'), actual_salary "    +
                                         "FROM accepted_workers as a, workers as w, positions as p " +
                                         "WHERE w.id = a.worker_id AND p.id = a.position_id");

        GetAllByStringCommand = new MySqlCommand("SELECT a.id, w.surname, w.name, w.patronymic, p.name, " +
                                                 "DATE_FORMAT(a.accept_date, '%d/%m/%Y'), actual_salary " +
                                                 "FROM accepted_workers as a, workers as w, positions as p " +
                                                 "WHERE w.id = a.worker_id AND p.id = a.position_id " +
                                                 "AND (@string = a.id OR @string = w.id OR @string = p.id " +
                                                 "OR LOCATE(@string, w.surname) > 0 OR LOCATE(w.surname, @string) > 0 " +
                                                 "OR LOCATE(@string, w.name) > 0 OR LOCATE(w.name, @string) > 0 " +
                                                 "OR LOCATE(@string, w.patronymic) > 0 OR LOCATE(w.patronymic, @string) > 0 " +
                                                 "OR LOCATE(@string, p.name) > 0 OR LOCATE(p.name, @string) > 0 " +
                                                 "OR @string = DATE_FORMAT(a.accept_date, '%Y') OR @string = DATE_FORMAT(a.accept_date, '%m') " +
                                                 "OR @string = DATE_FORMAT(a.accept_date, '%d') OR @string = a.actual_salary)");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand = new MySqlCommand("DELETE FROM accepted_workers WHERE id = @id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
}