using CourseWork2.Model;
using CourseWork2.Repositories.Abstractions;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class WorkerRepository : RepositoryBase<WorkerModel>, IWorkerRepository
{
    public WorkerRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT w.id, w.surname, w.name, w.patronymic, w.gender, w.status,"     +
                                          " w.military_registration, d.name FROM workers as w, departments as d " +
                                          "WHERE d.id = w.department_id AND w.id=@id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));

        GetAllCommand = new MySqlCommand("SELECT w.id, w.surname, w.name, w.patronymic, w.gender, w.status,"     +
                                         " w.military_registration, d.name FROM workers as w, departments as d " +
                                         "WHERE d.id = w.department_id");

        GetAllByStringCommand = new MySqlCommand("SELECT w.id, w.surname, w.name, w.patronymic, w.gender, w.status," +
                                                 " w.military_registration, d.name FROM workers as w, departments as d " +
                                                 "WHERE d.id = w.department_id AND (@string = w.id " +
                                                 "OR @string = d.id OR @string = status " +
                                                 "OR LOCATE(@string, d.name) > 0 OR LOCATE(d.name, @string) > 0 " +
                                                 "OR LOCATE(@string, surname) > 0 OR LOCATE(surname, @string) > 0 " +
                                                 "OR LOCATE(@string, patronymic) > 0 OR LOCATE(patronymic, @string) > 0 " +
                                                 "OR LOCATE(@string, w.name) > 0 OR LOCATE(w.name, @string) > 0)");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));

        DeleteCommand = new MySqlCommand("DELETE FROM workers WHERE id=@id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
        
        AddCommand = new MySqlCommand("INSERT INTO workers (surname, name, patronymic, gender, status, military_registration, department_id)" +
                                      "VALUE (@surname, @name, @patronymic, @gender, @status, @military, @department_id)");
        AddCommand.Parameters.Add(new MySqlParameter("@surname", MySqlDbType.VarChar));
        AddCommand.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar));
        AddCommand.Parameters.Add(new MySqlParameter("@patronymic", MySqlDbType.VarChar));
        AddCommand.Parameters.Add(new MySqlParameter("@gender", MySqlDbType.VarChar));
        AddCommand.Parameters.Add(new MySqlParameter("@status", MySqlDbType.VarChar));
        AddCommand.Parameters.Add(new MySqlParameter("@military", MySqlDbType.UInt16));
        AddCommand.Parameters.Add(new MySqlParameter("@department_id", MySqlDbType.Int32));
    }

    public Task EditAsync(WorkerModel worker)
    {
        throw new NotImplementedException();
    }

    //TODO: Переписать все запросы, чтобы было LEFT JOIN, для отображение всех данных таблицы
}