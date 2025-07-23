using FurniShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class FurniShopDbContext : DbContext
    {
        public FurniShopDbContext(DbContextOptions<FurniShopDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<BankCartInformation> BankCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckLevelLog> CheckLevelLogs { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SellerPayout> SellerPayouts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Product_DiscountCode> Product_DiscountCode { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRoles>().HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<CartItem>()
            .HasOne(ci => ci.ShoppingCart)
            .WithMany(sc => sc.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
            .HasOne(ci => ci.User)
            .WithMany(sc => sc.Reviews)
            .HasForeignKey(ci => ci.User_Id)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProductAttribute>()
                .HasKey(pa => new { pa.ProductId, pa.AttributeId });

            modelBuilder.Entity<ProductAttribute>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<ProductAttribute>()
                .HasOne(pa => pa.Attribute)
                .WithMany(p => p.ProductAttributes)
                .HasForeignKey(pa => pa.AttributeId);

            modelBuilder.Entity<Product_DiscountCode>()
                .HasKey(pd => new { pd.ProductId, pd.CodeId });

            modelBuilder.Entity<Product_DiscountCode>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.Product_DiscountCode)
                .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<Product_DiscountCode>()
                .HasOne(pa => pa.DiscountCode)
                .WithMany(p => p.Product_DiscountCode)
                .HasForeignKey(pa => pa.CodeId);


            // ساختن مقدار پیشفرض در دیتابیس
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Admin" },
                new Roles { RoleId = 2, RoleName = "Seller" },
                new Roles { RoleId = 3, RoleName = "Customer" }
                );
        }

    }
}
