﻿using AutoMapper;
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
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, IMapper mapper, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> Register(RegisterUserDto registerUserDto)
        {

            var identityUser = _mapper.Map<User>(registerUserDto); 
            var identityResult = await _userManager.CreateAsync(identityUser, registerUserDto.Password);

            return identityResult;
        }

        public async Task<string> LogIn(LogInUserDto userDto)
        {

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(userDto.EmailAddress, userDto.Password, false, false);
            if (signInResult.Succeeded)
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
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

           var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, identityUser.Email),
                
            };

            IList<string> roleNames = await _userManager.GetRolesAsync(identityUser);
            claims.AddRange(roleNames.Select(roleName => new Claim(ClaimsIdentity.DefaultRoleClaimType, roleName)));

            var jwtSecurityToken = new JwtSecurityToken
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

        public async Task<UserDto> GetCurrentUserAsync(string email)
        {
            var user =await _userManager.FindByNameAsync(email);
            var identityUser = _mapper.Map<UserDto>(user);
            return identityUser;
        }

        public static async Task CreateDefaultAdmin(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            bool x = await roleManager.RoleExistsAsync("Admin");
            if (!x)
            { 
                var role = new Role();
                role.Name = "Admin";
                await roleManager.CreateAsync(role);
           

                var user = new User();
                user.Email = "admin@admin.com";
                user.UserName = user.Email;
                user.Surname = "admin";
                user.Name = "admin";

                string password = "Qwe123!";

                var identityUser = await userManager.CreateAsync(user, password);

                if (identityUser.Succeeded)
                {
                    var result1 = await userManager.AddToRoleAsync(user, "Admin");
                }
            }

        }
    }
}
