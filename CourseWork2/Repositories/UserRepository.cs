using System.Net;
using CourseWork2.Model;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();
        Task                        task       = connection.OpenAsync();

        command.CommandText = "SELECT * FROM Users WHERE Username=@username and Password=@password";
        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;

        await task;
        return command.ExecuteScalar() is not null;
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

    public async Task<UserModel> GetByUsername(string username)
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();
        Task                        task       = connection.OpenAsync();

        command.CommandText = "SELECT * FROM Users WHERE Username=@username";

        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;

        await task;
        await using MySqlDataReader reader = command.ExecuteReader();

        reader.Read();
        var user = new UserModel
        {
            Username = reader[1].ToString()!,
            Password = string.Empty,
            Email    = reader[3].ToString()!,
            Role     = reader[4].ToString()!
        };

        return user;
    }

    public IEnumerable<UserModel> GetAll()
    {
        throw new NotImplementedException();
    }
}