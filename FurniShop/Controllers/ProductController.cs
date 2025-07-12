using Microsoft.AspNetCore.Mvc;

namespace FurniShop.Controllers
{
    [Route("/Product")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
