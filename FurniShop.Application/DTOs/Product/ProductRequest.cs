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
        public string ProductDescription { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public decimal OrginalPrice { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public string CategoryName { get; set; } = null!;

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public int UserId { get; set; }
        public DiscountType DiscountType { get; set; } = DiscountType.None;
        public decimal? Discount { get; set; }

        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        public string ProductNumber { get; set; } = null!;
    }

    public enum DiscountType
    {
        None = 0,
        Fixed = 1,
        Persent = 2
    }
}
