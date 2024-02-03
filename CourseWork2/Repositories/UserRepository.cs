using System.Net;
using CourseWork2.Model;
using CourseWork2.Repositories.Abstractions;
using MySql.Data.MySqlClient;

namespace CourseWork2.Repositories;

public class UserRepository : RepositoryBase<UserModel>, IUserRepository
{
    public UserRepository()
    {
        GetByUsernameCommand = new MySqlCommand("SELECT u.id, u.username, u.email, u.role " +
                                                "FROM users AS u WHERE username=@username");
        GetByUsernameCommand.Parameters.Add(new MySqlParameter("@username", MySqlDbType.VarChar));

        AuthUserCommand = new MySqlCommand("SELECT u.id, u.username, u.email, u.role " +
                                           "FROM users AS u WHERE username=@username AND password=@password");
        AuthUserCommand.Parameters.Add("@username", MySqlDbType.VarChar);
        AuthUserCommand.Parameters.Add("@password", MySqlDbType.VarChar);
    }

    private MySqlCommand GetByUsernameCommand { get; }

    private MySqlCommand AuthUserCommand { get; }

    public Task<UserModel?> AuthenticateUserAsync(NetworkCredential credential)
    {
        return GetValueAsync(AuthUserCommand, [credential.UserName, credential.Password]);
    }

    public Task EditAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel?> GetByUsernameAsync(string username)
    {
        return GetValueAsync(GetByUsernameCommand, [username]);
    }
}