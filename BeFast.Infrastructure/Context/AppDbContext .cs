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
        public DbSet<User> Users { get; set; }
        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItens> OrderItens { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
