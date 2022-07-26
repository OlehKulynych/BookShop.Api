using BookShop.Api.Models;
using BookShop.Api.Repositories;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto user)
        {

            var result = await _userService.Register(user);
            
            if (result)
            {
                return Ok();
            }
            else
            {
                string errorMessage = "Error register... Сheck the entered data.";              
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }

        [Route("SignIn")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInUserDto userDto)
        {

            var tokenResult = await _userService.LogIn(userDto);
            if (tokenResult != null)
            {
              
                return Ok(tokenResult);

            }
            else
            {
                return Unauthorized(userDto);
            }
        }

    }
}
