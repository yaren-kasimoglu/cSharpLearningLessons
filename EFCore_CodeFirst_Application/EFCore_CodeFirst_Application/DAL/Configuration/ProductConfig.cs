using EFCore_CodeFirst_Application.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductCode).HasMaxLength(100);
            builder.Property(x => x.ProductName).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);

        }
    }
}
