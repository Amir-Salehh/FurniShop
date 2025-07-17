using FurniShop.Application.DTOs.Product;
using FurniShop.Application.Interfaces;
using FurniShop.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductRequest request)
        {
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
    }
}
