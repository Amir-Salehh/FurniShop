using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FurniShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
