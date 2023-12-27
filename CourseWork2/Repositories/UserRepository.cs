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

        AuthUserCommand = new MySqlCommand("SELECT * FROM users WHERE username=@username AND password=@password");
        AuthUserCommand.Parameters.Add("@username", MySqlDbType.VarChar);
        AuthUserCommand.Parameters.Add("@password", MySqlDbType.VarChar);
    }

    private MySqlCommand GetByUsernameCommand { get; }

    private MySqlCommand AuthUserCommand { get; }

    public async Task<bool> AuthenticateUserAsync(NetworkCredential credential)
    {
        return await GetValueAsync(AuthUserCommand, [credential.UserName, credential.Password]) is not null;
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
        return await GetValueAsync(GetByUsernameCommand, [username]);
    }
}