using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.User
{
    public class BankCartRequest
    {
        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [StringLength(maximumLength:16, MinimumLength = 16,ErrorMessage = "شماره کارت باید شانزده رقمی باشد")]
        public string CartNumber { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [DisplayName("نام کارت")]
        public string CartName { get; set; } = null!;


    }
}
