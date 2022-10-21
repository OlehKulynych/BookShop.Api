using AutoMapper;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BookShop.Api.Repositories.Services
{
    public class UserService: IUserService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<bool> Register(RegisterUserDto registerUserDto)
        {

            var identityUser = _mapper.Map<User>(registerUserDto); 
            var identityResult = await _userManager.CreateAsync(identityUser, registerUserDto.Password);

            if(identityResult.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<string> LogIn(LogInUserDto userDto)
        {

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(userDto.EmailAddress, userDto.Password, false, false);
            if (signInResult.Succeeded == true)
            {
                User identityUser = await _userManager.FindByNameAsync(userDto.EmailAddress);
                string JSONWebTokenAsString = await GenerateJsonWebToken(identityUser);
                return JSONWebTokenAsString;
            }
            else
            {
                return null;
            }
        }

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
