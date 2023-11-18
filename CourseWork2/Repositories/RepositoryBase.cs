using Microsoft.Data.SqlClient;

namespace CourseWork2.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase()
        {
            _connectionString = "SERVER=(localdb)\\mssqllocaldb;DATABASE=master;Trusted_Connection=true;";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}