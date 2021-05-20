using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PromotionCodeAPI.Repositories;
using PromotionCodeAPI.Domain;
using PromotionCodeAPI.Dtos;
using System;
using PromotionCodeAPI.Services;

namespace PromotionCodeAPI.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService ??
                throw new ArgumentNullException(nameof(_userService));

            _mapper = mapper;
        }

        /// POST api/user
        /// <summary>
        /// Adds a user dto
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>A User Dto object with a unique userId</returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<UserDto> AddUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            _userService.AddUser(user);

            // Map back to the Dto to return to the API
            UserDto userMapDto = _mapper.Map<UserDto>(user);

            return CreatedAtRoute("GetUserByEmail",
                new
                {
                    email = userMapDto.Email
                }, userMapDto);
        }

        /// <summary>
        /// Get a specific user from the list
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Single user</returns>
        /// Get api/user/{userId}
        [AllowAnonymous]
        [HttpGet("email/{email}", Name = "GetUserByEmail")]
        public ActionResult<UserDto> GetUserByEmail(string email)
        {
            User userRepo = _userService.GetUser(email);

            if (userRepo == null)
            {
                return NotFound(_mapper.Map<UserDto>(userRepo));
            }

            return Ok(userRepo);
        }
    }
}
