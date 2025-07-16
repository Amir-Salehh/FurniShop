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
        public ICollection<Category> Categories { get; set; } = null!;

        [ForeignKey("DiscountCode")]
        public int CodeId { get; set; }
        public DiscountCode? Code { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;
        
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; } = null!;

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public ICollection<ProductDetail> Product_Detail { get; set; } = null!;

        public ICollection<Review>? Reviews { get; set; }
    }
}
