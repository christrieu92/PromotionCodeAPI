using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromotionCodeAPI.Authentication;
using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Services;

namespace PromotionCodeAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;

        public AccountController(IUserService userService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _userService = userService;
            _jWTAuthenticationManager = jWTAuthenticationManager;
        }

        /// <summary>
        /// User can login to be authenticated and receive a JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns a Token</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            var existingUser = _userService.GetUser(user.UserName, user.Password);

            if (existingUser == null)
            {
                return Unauthorized();
            }

            var token = _jWTAuthenticationManager.Authenticate(user.UserName);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}