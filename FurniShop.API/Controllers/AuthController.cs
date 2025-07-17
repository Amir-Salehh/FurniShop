using FurniShop.Application.DTOs.Auth;
using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }

        #region Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           if(await _service.CheckUserAsync(request.Email, request.PhoneNumber))
            {
                return BadRequest("شماره تلفن یا ایمیل وجود دارد");
            }

            byte[] salt = RandomNumberGenerator.GetBytes(16);

            string HashedPassword = PasswordHelper.HashPasswordBase64(request.Password, salt);


            var userRoles = new List<UserRoles>
                {
                    new UserRoles{ RoleId = 3 },
                };

            if (request.CheckSeller)
            {
                userRoles.Add(new UserRoles { RoleId = 2 });
            }
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Addresses = null,
                Password = HashedPassword,
                saltpassword = salt,
                CreatedAt = DateTime.UtcNow,
                UserRoles = userRoles
            };
            

            await _service.RegisterUserAsync(user);
            return Created();
        }
        #endregion

        #region Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if( !await _service.CheckExistAsync(request.EmailPhone))
            {
                return NotFound("ایمیل یا شماره تلفن وارد شده وجود ندارد");
            }

            var token = await _service.CheckLoginAsync(request.EmailPhone, request.Password, request.RememberMe);

            return Ok(new { Token=token });

        }
        #endregion
    }
}
