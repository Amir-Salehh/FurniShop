﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ProductAttribute
    {
        public int ProductId { get; set; }

        public int AttributeId { get; set; }

        public string Value { get; set; } = null!;

        public Product Product { get; set; }

        public Attributes Attribute { get; set; }

    }
}
