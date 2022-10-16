using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterUserDto registerUserDto);
        Task<string> LogIn(LogInUserDto userDto);
        Task<UserDto> GetCurrentUserAsync(string email);
    }
}
