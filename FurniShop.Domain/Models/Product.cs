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
        public int Product_Id { get; set; }

        [ForeignKey("Category")]
        public int Category_Id  { get; set; }
        public ICollection<Category> Categories { get; set; }

        [ForeignKey("DiscountCode")]
        public int CodeId { get; set; }
        public DiscountCode Code { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }
        
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Created_At { get; set; }

        public DateTime Updated_At { get; set; }

        public ICollection<ProductDetail> Product_Detail { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
