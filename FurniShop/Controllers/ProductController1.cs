using Microsoft.AspNetCore.Mvc;

namespace FurniShop.Controllers
{
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
