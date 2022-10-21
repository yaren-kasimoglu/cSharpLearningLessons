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
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(ci => ci.CityId);
            builder.Property(ci => ci.CityName).HasMaxLength(255);
            builder.HasOne(c => c.Country).WithMany(ci => ci.Cities).HasForeignKey(t => t.CountryId).OnDelete(DeleteBehavior.Restrict); 

            builder.HasData(

            new City() { CityId = 1, CityName = "Adana", CountryId = 1 },
            new City() { CityId = 2, CityName = "Adıyaman", CountryId = 1 },
            new City() { CityId = 3, CityName = "Afyon", CountryId = 1 },
            new City() { CityId = 4, CityName = "Ağrı", CountryId = 1 });

        }
    }
}
