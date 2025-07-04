﻿using FurniShop.Application.Interfaces;
using FurniShop.Application.Security;
using FurniShop.Application.ViewModels;
using FurniShop.Domain.Models;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FurniShop.Areas.Authentication.Controllers
{
    [Area("Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginPost(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_userService.CheckExist(model.EmailPhone))
            {
                TempData["Message"] = "ایمیل یا شماره تلفن وجود ندارد";
                return RedirectToAction("Login");
            }
            if (!_userService.CheckLogin(model.EmailPhone, model.Password)) 
            {
                TempData["Message"] = "رمز عبور اشتباه میباشد";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Index", "Home");
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

            byte[] salt = RandomNumberGenerator.GetBytes(16);

            string Hashed = PasswordHelper.HashPasswordBase64(model.Password, salt).ToString();

            User user = new User()
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = Hashed,
                saltpassword = salt,
                PhoneNumber = model.PhoneNumber
            };
            if (_userService.CheckUser(model.Email, model.Password))
            {
                TempData["Message"] = "نام کاربری یا رمز عبور اشتباه است";
                return RedirectToAction("Register");
            }
            else 
            {
                _userService.RegisterUser(user);
                TempData["Message"] = "ثبت نام موفقیت آمیز بود.";
                return RedirectToAction("Login");
            }

        }
    }
}
