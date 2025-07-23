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

            await _service.RegisterUserAsync(request);
            return Created();
        }
        #endregion

        #region Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if( !await _service.CheckExistAsync(request.EmailPhone))
            {
                return NotFound("ایمیل یا شماره تلفن وارد شده وجود ندارد");
            }

            try
            {
                var token = await _service.CheckLoginAsync(request);
                return Ok(new { Token=token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        #endregion

    }
}
