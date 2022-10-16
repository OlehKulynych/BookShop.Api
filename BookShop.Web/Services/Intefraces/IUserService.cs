using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IUserService
    {
        Task<UserDto> GetCurrentUser(string email);
    }
}
