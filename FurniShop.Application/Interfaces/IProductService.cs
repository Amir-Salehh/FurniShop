using FurniShop.Application.ViewModels.Product;
using FurniShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniShop.Application.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();
    }
}
