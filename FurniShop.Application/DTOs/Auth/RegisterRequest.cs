using System.ComponentModel.DataAnnotations;

namespace FurniShop.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(120)]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره موبایل باید 11 رقم باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "شماره موبایل معتبر نیست.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [EmailAddress(ErrorMessage = "ایمیل صحیح نمیباشد")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "رمز عبور باید حداقل ۸ کاراکتر و شامل حروف کوچک، بزرگ و عدد باشد.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(250)]
        [Compare("Password", ErrorMessage = "Password و ConfirmPassword باید برابر باشند")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;

    }
}
