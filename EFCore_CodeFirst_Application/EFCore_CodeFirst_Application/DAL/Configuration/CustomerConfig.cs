using EFCore_CodeFirst_Application.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EFCore_CodeFirst_Application.DAL.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.CustomerName).HasMaxLength(255);
            builder.Property(c => c.Phone).HasMaxLength(255);
            builder.Property(c => c.Address).HasMaxLength(255);
            builder.Property(c => c.Email).HasMaxLength(255);

            builder.HasOne(c=>c.Country).WithMany().HasForeignKey(c=>c.CountryId).OnDelete (DeleteBehavior.Restrict);
            builder.HasOne(ci => ci.City).WithMany().HasForeignKey(ci => ci.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
