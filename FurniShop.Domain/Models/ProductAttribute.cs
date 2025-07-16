using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ProductAttribute
    {
        [Key]
        public int Attribute_Id { get; set; }

        public string? Attribute_Name { get; set; }

    }
}
