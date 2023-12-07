using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public abstract class RepositoryBase
{
    private const string ConnectionString = "Server=localhost;Database=CourseWorkDB;Uid=root;Pwd=562389;";
    
    protected static MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }
}