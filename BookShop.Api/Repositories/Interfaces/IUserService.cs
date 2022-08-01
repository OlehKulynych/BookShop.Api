using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(RegisterUserDto registerUserDto);
        Task<string> LogIn(LogInUserDto userDto);
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
