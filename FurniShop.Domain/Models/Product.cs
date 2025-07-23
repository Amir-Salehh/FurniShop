using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId  { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public decimal? Discount { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;
        
        public decimal OrginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string ProductNumber { get; set; } = null!;

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public ICollection<ProductAttribute>? ProductAttributes { get; set; } 

        public ICollection<Review>? Reviews { get; set; }

        public ICollection<Product_DiscountCode> Product_DiscountCode { get; set; }
    }

}
