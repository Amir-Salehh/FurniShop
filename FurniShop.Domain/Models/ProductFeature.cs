using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Domain.Models
{
    public class ProductFeature
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string FeatureDescription { get; set; }

        //FK
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
