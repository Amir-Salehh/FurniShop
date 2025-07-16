using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Auth
{
    public class LoginRequest : IValidatableObject
    {
        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(255)]
        public string EmailPhone { get; set; } = null!;

        [Required(ErrorMessage = "این پارامتر نمیتواند خالی باشد")]
        [StringLength(255)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsEmailValid(EmailPhone) && !IsPhoneNumberValid(EmailPhone))
            {
                yield return new ValidationResult("لطفاً یک ایمیل یا شماره موبایل معتبر وارد کنید.", new[] { nameof(EmailPhone) });
            }
        }

        private bool IsEmailValid(string input)
        {
            return new EmailAddressAttribute().IsValid(input);
        }

        private bool IsPhoneNumberValid(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^(\+98|0)?9\d{9}$");
        }
    }
}
