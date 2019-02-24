using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ProductApi.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<ProductItem> ProductItems { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<ProductItem>()
        //         .Property<string[]>("stores")
        //         .HasField("_stores");
    }
}