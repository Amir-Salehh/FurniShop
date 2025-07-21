using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.DTOs.Product
{
    public class ProductRequest
    {
        [Required(ErrorMessage ="این فیلد نمیتواند خالی باشد")]
        [MaxLength(100)]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [MaxLength(500)]
        public string ProductDescription { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public decimal OrginalPrice { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public string CategoryName { get; set; } = null!;

        public DiscountType DiscountType { get; set; } = DiscountType.None;
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "کد کالا باید 5 کاراکتر باشد")]
        public string ProductNumber { get; set; } = null!;

        public List<string>? AtributeName { get; set; }
        public List<string>? AtributeValue { get; set; }

    }

    public enum DiscountType
    {
        None = 0,
        Fixed = 1,
        Persent = 2
    }
}
