using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeController : ControllerBase
    {
        private readonly IDiscountCodeService _discountCodeService;
        public DiscountCodeController(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }


        #region Get All Discount Codes
        [HttpGet("GetAllCodes")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var Codes = _discountCodeService.GetAll();

            if(Codes == null || Codes.Count == 0)
            {
                return BadRequest("کد تخفیفی وجود ندارد");
            }
            return Ok(Codes);
        }
        #endregion

        #region Create DiscountCode
        [HttpPost]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> Create([FromBody] DiscountCodeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _discountCodeService.CheckExist(request.Code))
            {
                return BadRequest("این کد تخفیف وجود دارد");
            }

            try
            {
                await _discountCodeService.Create(request);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        #endregion

    }
}
