using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Domain.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using FurniShop.Application.ViewModels.Auth;
using System.Threading.Tasks;


namespace FurniShop.Controllers
{
    [Route("Auth/{action}")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginPost(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await _userService.CheckExistAsync(model.EmailPhone))
            {
                TempData["Message"] = "ایمیل یا شماره تلفن وجود ندارد";
                return RedirectToAction("Login");
            }
            var result = await _userService.CheckLoginAsync(model.EmailPhone, model.Password);
            if (! result.IsValid)
            {
                TempData["Message"] = "رمز عبور اشتباه میباشد";
                return RedirectToAction("Login");
            }

            var user = result.user;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.role.ToString()),
                new Claim("Email", user.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPost(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            byte[] salt = RandomNumberGenerator.GetBytes(16);

            string Hashed = PasswordHelper.HashPasswordBase64(model.Password, salt);

            User user = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = Hashed,
                saltpassword = salt,
                PhoneNumber = model.PhoneNumber,
            };
            if ( await _userService.CheckUserAsync(model.Email, model.PhoneNumber))
            {
                TempData["Message"] = "ایمیل یا شماره تلفن وجود دارد";
                return RedirectToAction("Register");
            }
            else 
            {
                _userService.RegisterUser(user);
                TempData["Message"] = "ثبت نام موفقیت آمیز بود.";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
