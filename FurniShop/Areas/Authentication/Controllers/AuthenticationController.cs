using FurniShop.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FurniShop.Areas.Authentication.Controllers
{
    [Route("Authentication")]
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterPost(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Message"] = "ثبت نام موفقیت آمیز بود.";
            return RedirectToAction("Login");
        }
    }
}
