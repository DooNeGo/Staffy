using System.Net;
using CourseWork2.Model;
using CourseWork2.Repositories.Abstractions;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class UserRepository : RepositoryBase<UserModel>, IUserRepository
{
    public UserRepository()
    {
        GetByUsernameCommand = new MySqlCommand("SELECT * FROM users WHERE username=@username");
        GetByUsernameCommand.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar));
    }
    
    private MySqlCommand GetByUsernameCommand { get; }
    
    public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
    {
        await using MySqlConnection connection = GetConnection();
        await using MySqlCommand    command    = connection.CreateCommand();

        Task task = connection.OpenAsync();

        command.CommandText = "SELECT * FROM users WHERE username=@username and password=@password";
        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;

        await task;
        return command.ExecuteScalar() is not null;
    }

    public async Task AddAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public async Task EditAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        await using MySqlConnection connection = GetConnection();
        await connection.OpenAsync();
        return await GetValueAsync(GetByUsernameCommand, connection, [username]);
    }
}