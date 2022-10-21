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
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);
            builder.Property(c => c.CityName).HasMaxLength(255);

            builder.HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

    new City() { CityId = 1, CityName = "Adana", CountryId = 1 },
    new City() { CityId = 2, CityName = "Adıyaman", CountryId = 1 },
    new City() { CityId = 3, CityName = "Afyon", CountryId = 1 },
    new City() { CityId = 4, CityName = "Ağrı", CountryId = 1 });

        }
    }
}
