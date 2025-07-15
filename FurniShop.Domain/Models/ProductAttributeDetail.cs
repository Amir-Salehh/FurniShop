using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ProductAttributeDetail
    {
        [Key]
        public int Product_Attribute_Detail_Id { get; set; }

        [ForeignKey("Product_Detail")]
        public int Product_Detail_Id {  get; set; }

        [ForeignKey("Product_Attribute")]
        public int Product_Attribute { get; set; }

        public string Value { get; set; }
    }
}
