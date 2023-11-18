using CourseWork2.Model;
using Microsoft.Data.SqlClient;
using System.Net;

namespace CourseWork2.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
        {
            using SqlConnection connection = GetConnection();

            await connection.OpenAsync();
            var info = connection.Database;


            return false;
            //using SqlCommand command = connection.CreateCommand();

            //command.CommandText = "select all from [User] where username=@username and password";

        }

        public async Task Add(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task Edit(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
