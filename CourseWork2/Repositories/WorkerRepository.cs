using CourseWork2.Model;
using CourseWork2.Repositories.Abstractions;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class WorkerRepository : RepositoryBase<WorkerModel>, IWorkerRepository
{
    public WorkerRepository()
    {
        GetByIdCommand = new MySqlCommand("SELECT * FROM workers WHERE id=@id");
        GetByIdCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
        
        GetAllCommand = new MySqlCommand("SELECT * FROM workers");

        GetAllByStringCommand = new MySqlCommand("SELECT * FROM workers WHERE LOCATE(@string, name) > 0 "       +
                                                 "OR LOCATE(@string, surname) > 0 OR LOCATE(@string, patronymic) > 0 " +
                                                 "OR LOCATE(@string, gender) > 0 OR LOCATE(@string, status) > 0");
        GetAllByStringCommand.Parameters.Add(new MySqlParameter("@string", MySqlDbType.VarChar));
        
        DeleteCommand = new MySqlCommand("DELETE FROM workers WHERE id=@id");
        DeleteCommand.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32));
    }
    
    public Task Add(WorkerModel worker)
    {
        throw new NotImplementedException();
    }

    public Task Edit(WorkerModel worker)
    {
        throw new NotImplementedException();
    }
}