using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeFast.Infrastructure.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItens> OrderItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurants>()
       .HasOne(r => r.User)
       .WithMany(u => u.Restaurants)
       .HasForeignKey(r => r.UserId)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CustomerOrders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasMany(u => u.DeliveryOrders)
                .WithOne(o => o.DeliveryPerson)
                .HasForeignKey(o => o.DeliveryPersonId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>()
                .HasMany(o => o.OrderItens)
                .WithOne(oi => oi.Order)
               .HasForeignKey(oi => oi.OrderId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Products>()
                .HasMany(p => p.OrderItens)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Orders>()
                .HasMany(o => o.Payments)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrdersId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
