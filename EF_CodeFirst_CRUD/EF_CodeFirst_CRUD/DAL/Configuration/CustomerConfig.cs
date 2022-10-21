using EF_CodeFirst_CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_CRUD.DAL.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.CustomerName).HasMaxLength(255);
            builder.Property(c => c.Phone).HasMaxLength(50);
            builder.Property(c => c.Address).HasMaxLength(1000);
            builder.Property(c => c.Email).HasMaxLength(255);

            //oneToZero
            builder.HasOne(t0 => t0.Country).WithMany().HasForeignKey(t1 => t1.CountryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t0 => t0.City).WithMany().HasForeignKey(t1 => t1.CityId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
