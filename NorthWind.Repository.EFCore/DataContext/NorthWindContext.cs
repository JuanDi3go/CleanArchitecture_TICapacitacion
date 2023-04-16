using Microsoft.EntityFrameworkCore;
using NorthWay.Entities.PocoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Repository.EFCore.DataContext
{
    public class NorthWindContext:DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options):base(options) { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Customer
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(40);

            //Product
            modelBuilder.Entity<Product>().Property(c => c.Name).IsRequired().HasMaxLength(40);

            //order
            modelBuilder.Entity<Order>().Property(c => c.CustomerId).IsRequired().HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Order>().Property(c => c.ShipAdress).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Order>().Property(c => c.ShipCity).HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(c => c.ShipCountry).HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(c => c.ShipPostalCode).HasMaxLength(10);
            modelBuilder.Entity<Order>().HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId);
      

            //orderDetail
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<OrderDetail>().HasOne<Product>().WithMany().HasForeignKey(o => o.ProductId);


            //Seeds

            modelBuilder.Entity<Product>().HasData(new Product { Id= 1, Name = "Chai"},
                new Product { Id= 2, Name = "Chang"}, new Product { Id = 3,Name= "anised Syrup"});



            modelBuilder.Entity<Customer>().HasData(
                new Customer {Id= "ALFAK",Name= "Alfreds F" },
                new Customer {Id= "ANATR",Name= "Ana Trujillo" },
                new Customer {Id= "ANTON",Name= "Antonio Moreno" }
                );
        }
    }
}
