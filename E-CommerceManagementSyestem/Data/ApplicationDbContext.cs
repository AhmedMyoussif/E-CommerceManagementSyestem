using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_CommerceManagementSyestem.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_CommerceManagementSyestem
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7DSEHP1;Initial Catalog = E-Commerce;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOption>()
                 .HasKey(x => x.ProductOptionId);

            modelBuilder.Entity<ProductOption>()
                .HasOne(p => p.Product)
                .WithMany(x=>x.ProductOptions)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductOption>()
                .HasOne(p => p.Option)
                .WithMany()
                .HasForeignKey(p => p.OptionId);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => pc.ProductCategoryId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.roductCategories)
                .HasForeignKey(pc => pc.CategoryId);


            modelBuilder.Entity<Customer>()
                .Property(p =>p. Default_Shipping_Address)
                .HasDefaultValue("Pending");
                modelBuilder.Entity<Customer>()
                .Property(p =>p.Country)
                .HasDefaultValue("Egypt");

            modelBuilder.Entity<Order>()
                .Property(p => p.ShippingAddress)
                .HasDefaultValue("Egypt"); 
            modelBuilder.Entity<Order>()
                .Property(p => p.OrderAddress)
                .HasDefaultValue("Egypt");

            modelBuilder.Entity<Product>()
                .Property(p => p.Stock)
                .HasDefaultValue(1);
            modelBuilder.Entity<Option>()
                .Property(o => o.OptionName)
                .HasColumnType("nvarchar(MAX)");

        }
        public DbSet<Customer> Customers { get; set; }
           public DbSet<Order> Orders { get; set; }
           public DbSet<Category> Categories { get; set; }
           public DbSet<Option> Options { get; set; }
           public DbSet<OrderDetail> OrderDetails { get; set; }
           public DbSet<Product> Products { get; set; }
           public DbSet<ProductOption> ProductOptions { get; set; }


    }
}
