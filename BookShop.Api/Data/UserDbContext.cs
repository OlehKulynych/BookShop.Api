using BookShop.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BookShop.Api.Data
{
    public class UserDbContext:IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }
    }
}
