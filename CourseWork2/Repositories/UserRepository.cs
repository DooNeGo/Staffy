using System.Net;
using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        await using MySqlCommand command = connection.CreateCommand();

        command.CommandText = "SELECT * FROM Users WHERE Username=@username and Password=@password";
        command.Parameters.Add("username", MySqlDbType.VarChar).Value = credential.UserName;
        command.Parameters.Add("password", MySqlDbType.VarChar).Value = credential.Password;

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