using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(a => a.PictureUrl).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(a => a.Description).HasMaxLength(500);
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.HasOne(a => a.ProductBrand).WithMany().HasForeignKey(a => a.ProductBrandId);
            builder.HasOne(a => a.ProductType).WithMany().HasForeignKey(a => a.ProductTypeId);
        }
    }
}
