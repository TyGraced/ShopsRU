using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "T-Shirts",
                    IsGrocery = false,
                    Price = 2450
                },
                new Product
                {
                    Id = 2,
                    Name = "Bread",
                    IsGrocery = true,
                    Price = 520
                },
                new Product
                {
                    Id = 3,
                    Name = "Meat",
                    IsGrocery = true,
                    Price = 1470
                },
                new Product
                {
                    Id = 4,
                    Name = "Jeans",
                    IsGrocery = false,
                    Price = 2680
                },
                new Product
                {
                    Id = 5,
                    Name = "Pasta",
                    IsGrocery = true,
                    Price = 1230
                },
                new Product
                {
                    Id = 6,
                    Name = "Watermelon",
                    IsGrocery = true,
                    Price = 700
                },
                new Product
                {
                    Id = 7,
                    Name = "Singlet",
                    IsGrocery = false,
                    Price = 1130
                },
                new Product 
                { 
                    Id = 8,
                    Name = "Apple",
                    IsGrocery = true,
                    Price = 300
                },
                new Product
                {
                    Id = 9,
                    Name = "Boxers",
                    IsGrocery = false,
                    Price = 575
                });
        }
    }
}