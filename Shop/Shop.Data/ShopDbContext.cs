using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using Shop.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data
{
    //dotnet ef --startup-project ../Shop.Api migrations add CategoriesTabelCreated
    //dotnet ef --startup-project ../Shop.Api database update
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly()

            base.OnModelCreating(modelBuilder);
        }
    }
}
