using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class User
    {
    [Key]
    public int UserId { get; set; }

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

    [Required]
    [StringLength(250)]
    public string Password { get; set; }
    [Required]
    public byte[] saltpassword { get; set; }   

    public Role role { get; set; } = Role.User;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }


    public enum Role
    {
        Admin = 0,
        User = 1
    }

    public ICollection<Address> AddressList { get; set; } = new List<Address>();
    public ICollection<CartItem> cartItems { get; set; } = new List<CartItem>();
}
}
