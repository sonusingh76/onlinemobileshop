using Microsoft.AspNetCore.Mvc;
using MobileOnlineShopSystem.UserMicroservice.Business_Layer.DTO;
using MobileOnlineShopSystem.UserMicroservice.Business_Layer.Service;

namespace MobileOnlineShopSystem.UserMicroservice.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            try
            {
                _userService.RegisterUser(userDto);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var (token, userId) = _userService.Login(userLoginDto);
                return Ok(new { Token = token, UserId = userId });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

    }

}
