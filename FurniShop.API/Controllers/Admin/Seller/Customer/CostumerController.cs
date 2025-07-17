using FurniShop.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurniShop.API.Controllers.Admin.Seller.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Costumer")]
    public class CostumerController : ControllerBase
    {
        private IProductService _productService;
        public CostumerController(IProductService productService)
        {
            _productService = productService;
        }

        #region Get All Product
        [HttpGet("Get-All-Products")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }
        #endregion
    }
}
