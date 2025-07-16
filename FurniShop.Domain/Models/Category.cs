using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }

        public Category? Parent { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
