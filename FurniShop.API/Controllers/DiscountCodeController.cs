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
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var Codes = _discountCodeService.GetAll();

            if (Codes == null || Codes.Count == 0)
            {
                return BadRequest("کد تخفیفی وجود ندارد");
            }

            var codesDto = _mapper.Map<List<DiscountCodeResponseDTo>>(Codes);

            return Ok(codesDto);
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

        #region Update DiscountCode
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, Seller")]
        public async Task<IActionResult> Update(int id, [FromBody] DiscountCodeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await _discountCodeService.CheckExist(id))
            {
                return NotFound("کد تخفیف پیدا نشد");
            }

            await _discountCodeService.Update(request, id);

            return Ok("کد تخفیف آپدیت شد");
        }
        #endregion

    }
}
