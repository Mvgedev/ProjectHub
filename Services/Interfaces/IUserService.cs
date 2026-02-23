using ProjectHub.Api.DTOs;

namespace ProjectHub.Api.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserInfoAsync();
        Task<CreateUserDto> CreateUserAsync(CreateUserDto dto);
        Task UpdatePasswordAsync(string password);
        Task UpdateUserAsync(UserDto dto);
        Task DeleteUserAsync();
    }
}