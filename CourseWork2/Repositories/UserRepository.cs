using CourseWork2.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;

namespace CourseWork2.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
        {
            using SqlConnection connection = GetConnection();
            await connection.OpenAsync();
            using SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Users WHERE Username=@username and [Password]=@password";
            command.Parameters.Add("username", SqlDbType.NVarChar).Value = credential.UserName;
            command.Parameters.Add("password", SqlDbType.NVarChar).Value = credential.Password;

            return await command.ExecuteScalarAsync() is not null;
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
