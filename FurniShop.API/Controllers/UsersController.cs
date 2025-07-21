using FurniShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #region Get All Users
        [HttpGet("AllUsers")]
        [Authorize("Admin")]
        public IActionResult GetAll()
        {
            var users = _userService.GetUsers();

            if(users == null || users.Count == 0)
            {
                return NotFound("کاربری وجود ندارد");
            }

            return Ok(users);
        }
        #endregion

        #region Get Your Detail
        [HttpGet("GetProfile")]
        public IActionResult GetProfile()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var user = _userService.GetUserById(userId);
        
            return Ok(user);
        }
        #endregion
    }
}
