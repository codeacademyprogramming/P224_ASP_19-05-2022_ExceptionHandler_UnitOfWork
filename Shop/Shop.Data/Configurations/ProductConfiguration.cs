using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Title).HasMaxLength(255).IsRequired();
            builder.Property(b => b.Image).HasMaxLength(1000).IsRequired();
            builder.Property(b => b.Price).HasColumnType("decimal(18,2)").IsRequired();
        }
    }
}
