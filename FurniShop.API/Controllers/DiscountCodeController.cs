using AutoMapper;
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
        private readonly IMapper _mapper;
        public DiscountCodeController(IDiscountCodeService discountCodeService, IMapper mapper)
        {
            _discountCodeService = discountCodeService;
            _mapper = mapper;
        }


        #region Get All Discount Codes
        [HttpGet("DiscountCodes")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var Codes = _discountCodeService.GetAll();

            if(Codes == null || Codes.Count == 0)
            {
                return BadRequest("کد تخفیفی وجود ندارد");
            }

            var codesDto = _mapper.Map<List<DiscountCodeResponseDTo>>(Codes);

            return Ok(codesDto);
        }
        #endregion

        #region Create DiscountCode
        [HttpPost("Create")]
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

            if (request.CategoryId != null && request.ProductIds != null)
            {
                return BadRequest("محصولات مربوط به دسته بندی انتخاب شده اند");
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
