using Supermarket.Models;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.SuppliedProducts)
                .HasForeignKey(p => p.SupplierId);

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Groceries" },
                new Category { CategoryId = 2, Name = "Electronics" },
                new Category { CategoryId = 3, Name = "Clothing" }
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, CompanyName = "Supplier A", ContactPerson = "John Doe" },
                new Supplier { SupplierId = 2, CompanyName = "Supplier B", ContactPerson = "Jane Smith" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Milk", Price = 2.99m, CategoryId = 1, SupplierId = 1 },
                new Product { ProductId = 2, Name = "TV", Price = 499.99m, CategoryId = 2, SupplierId = 2 },
                new Product { ProductId = 3, Name = "Jeans", Price = 29.99m, CategoryId = 3, SupplierId = 1 }
            );
        }
    }
}