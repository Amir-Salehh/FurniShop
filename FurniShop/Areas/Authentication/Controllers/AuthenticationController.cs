using FurniShop.Application.ViewModels;
using FurniShop.Domain.Models;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

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
