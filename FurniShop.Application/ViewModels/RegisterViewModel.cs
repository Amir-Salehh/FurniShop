using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FurniShop.Domain.Models.User;

namespace FurniShop.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(120)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل باید 11 رقم باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نیست.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [EmailAddress(ErrorMessage = "ایمیل صحیح نمیباشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر و شامل حروف کوچک، بزرگ و عدد باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [Compare("Password", ErrorMessage = "Password و ConfirmPassword باید برابر باشند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
