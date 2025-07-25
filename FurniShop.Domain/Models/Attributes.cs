﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class Attributes
    {
        [Key]
        public int AttributeId { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
