using BookShop.Api.Models;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {
            string password = user.Password;

            User identityUser = new User
            {
                Email = user.EmailAddress,
                UserName = user.EmailAddress,
                Name = user.Name,
                Surname = user.Surname
            };

            IdentityResult identityResult = await _userManager.CreateAsync(identityUser, password);
            if(identityResult.Succeeded==true)
            {
                return Ok(new { identityResult.Succeeded });
            }
            else
            {
                string errorMessage = "Error register";
                foreach(var errors in identityResult.Errors)
                {
                    errorMessage += Environment.NewLine;
                    errorMessage += $"Code: {errors.Code} : {errors.Description}";
                    
                }
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [Route("LogIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInUserDto userDto)
        {
            string username = userDto.EmailAddress;
            string password = userDto.Password;

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if(signInResult.Succeeded == true)
            {
                User identityUser = await _userManager.FindByNameAsync(username);
                string JSONWebTokenAsString = await GenerateJsonWebToken(identityUser);
                return Ok(JSONWebTokenAsString);

            }
            else
            {
                return Unauthorized(userDto);
            }
        }

        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<string> GenerateJsonWebToken(User identityUser)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };

            IList<string> roleNames = await _userManager.GetRolesAsync(identityUser);
            claims.AddRange(roleNames.Select(roleName => new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
            (
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                null,
                expires: DateTime.UtcNow.AddDays(28),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
