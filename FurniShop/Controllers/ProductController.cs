using FurniShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FurniShop.Controllers
{
    [Route("/Product")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }
    }
}
