using FurniShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using FurniShop.Application.Profiles;
using FurniShop.Application.DTOs.User;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #region Get All Users
        [HttpGet("AllUsers")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var users = _userService.GetUsers();

            if(users == null || users.Count == 0)
            {
                return NotFound("کاربری وجود ندارد");
            }

            var UserDto = _mapper.Map<List<UserResponseDTo>>(users);

            return Ok(UserDto);
        }
        #endregion

        #region Get Your Detail
        [HttpGet("GetProfile")]
        public IActionResult GetProfile()
        {
            if(User.FindFirst(ClaimTypes.NameIdentifier) == null)
            {
                return NotFound("لطفا لاگین کنید");
            }

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var user = _userService.GetUserById(userId);
        
            return Ok(user);
        }
        #endregion

        #region Get Bank Cart
        [HttpGet("User/YourBankCart")]
        [Authorize(Roles = "Admin, Seller, Customer")]
        public async Task<IActionResult> GetBankCart()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await _userService.GetCart();

            if(cart == null)
            {
                return BadRequest("شما شماره کارتی را ثبت نکردید");
            }


            return Ok(cart);
        }
        #endregion

        #region Add Bank Cart
        [HttpPost("Create")]
        [Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> Create([FromBody] BankCartRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _userService.CheckHaveBankCart())
            {
                return BadRequest("شما قبلا یک کارت اضافه کرده اید");
            }
            await _userService.CreateCart(request);
            return Ok();
        }
        #endregion

        #region Update Bank Cart
        [HttpPut("Update/{id}")]
        [Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> Update(int id ,[FromBody] BankCartRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.CheckExistCart(id))
            {
                return BadRequest("این کارت وجود ندارد");
            }

            await _userService.UpdateCart(request);
            return Ok("کارت بانکی آپدیت شد");
        }
        #endregion

        #region Delete Bank Code
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await _userService.CheckExistCart(id))
            {
                return BadRequest("این  کارت وجود ندارد");
            }

            await _userService.DeleteCart(id);
            return Ok("با موفقیت حذف شد");
        }
        #endregion
    }
}
