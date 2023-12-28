using System.Net;
using CourseWork2.Model;

namespace CourseWork2.Repositories.Abstractions;

public interface IUserRepository
{
    public Task<bool> AuthenticateUserAsync(NetworkCredential credential);

    public Task AddAsync(UserModel user);

    public Task EditAsync(UserModel user);

    public Task RemoveAsync(int id);

    public Task<UserModel?> GetByUsernameAsync(string username);

    public Task<List<UserModel>> GetAllAsync();
}