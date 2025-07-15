using FurniShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class FurniShopDbContext : DbContext
    {
        public FurniShopDbContext(DbContextOptions<FurniShopDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get;set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<ProductDetail> productDetails { get; set; }
        public DbSet<Review> reviews { get; set; }
    }
}
