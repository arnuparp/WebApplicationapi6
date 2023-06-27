using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
  : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Transection> Transections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasIndex(e => e.Id_Product)
                .IsUnique();

            modelBuilder.Entity<Transection>()
              .HasIndex(e => e.Id_tran)
              .IsUnique();


        }


    }
}
