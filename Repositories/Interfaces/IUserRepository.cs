using ProjectHub.Api.Models;

namespace ProjectHub.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task UpdateUserPasswordAsync(string passwordHash, Guid id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
    }
}