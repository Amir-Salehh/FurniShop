using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FurniShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        #region Get All Product
        [HttpGet("Products")]
        public IActionResult CheckExistProductAcync() 
        {
            var products = _productService.GetAll();
            if (products == null)
            {
                return NotFound("محصولی وجود ندارد");
            }
            return Ok(products);
        }
        #endregion

        #region Create Product
        [HttpPost("Create")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _productService.CheckExistProductAsync(request.ProductNumber))
            {
                return BadRequest("این کد کالا وجود دارد");
            }

            if (!await _categoryService.CheckExistCategoryByName(request.CategoryName))
            {
                return BadRequest("این کتگوری وجود ندارد");
            }

            if (request.AtributeName!.Count != request.AtributeValue!.Count)
            {
                return BadRequest("تعداد ویژگی های وارد شده با تعداد مقادیرشون همخونی نداره");
            }

            if (request.AtributeName != null && request.AtributeValue == null)
            {
                return BadRequest($"ویژگی {request.AtributeName} باید مقدار داشته باشد");
            }

            await _productService.CreateProductAsync(request);
            return Ok("محصول با موفقیت ساخته شد");
        }
        #endregion

        #region Delete Product
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _productService.CheckExistProductAsync(id))
            {
                return BadRequest("محصول پیدا نشد");
            }

            try
            {
                await _productService.DeleteProduct(id);
                return Ok("با موفقیت حذف شد");
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }
        #endregion

        #region Get Seller Products
        [HttpGet("MyProducts")]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<IActionResult> MyProducts()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var products = await _productService.GetYourProducts(userId);
            if (products.Count == 0)
            {
                return NotFound("این کاربر محصولی ندارد");
            }
            return Ok(products);
        }
        #endregion

    }
}
