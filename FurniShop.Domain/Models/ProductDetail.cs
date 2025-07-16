using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ProductDetail
    {
        [Key]
        public int Product_Detail_Id { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product Product { get; set; } = null!;

        public ICollection<ProductAttributeDetail> Attribute { get; set; }

    }
}
