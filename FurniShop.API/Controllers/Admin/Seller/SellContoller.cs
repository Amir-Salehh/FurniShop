using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurniShop.API.Controllers.Admin.Seller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Seller")]
    public class SellContoller : ControllerBase
    {
        private IProductService _productService;
        public SellContoller(IProductService productService)
        {
            _productService = productService;
        }

        #region Get All Products
        [HttpGet("my-Products")]
        public IActionResult GetAllProducts()
        {
            var userIdClaim =  User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            var userId = int.Parse(userIdClaim.Value);
            var products =  _productService.GetProducts(userId).ToList();
            return Ok(products);
        }
        #endregion

        #region Create Product
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal discounedPrice = _productService.AddDiscount(request.OrginalPrice, request.Discount, request.DiscountType);

            string productNumber = _productService.GenerateProductNumber();

            Product product = new Product
            {
                ProductName = request.ProductName,
                ProductNumber = productNumber,
                ProductDescription = request.ProductDescription,
                OrginalPrice = request.OrginalPrice,
                DiscountedPrice = discounedPrice,
                Discount = request.Discount,
                Stock = request.Stock,
                UserId = request.UserId,
                ImageUrl = request.ImageUrl,
                Category = new Category { Name = request.CategoryName },
            };

            if(!await _productService.CheckExistProductAsync(productNumber)) 
            {
                return BadRequest("این محصول وجود دارد");
            }

            try
            {
                await _productService.CreateProductAsync(product);
                return Ok();
            }
            catch 
            {
                return BadRequest("محصول ساخته نشد");
            }

        }
        #endregion


    }
}
