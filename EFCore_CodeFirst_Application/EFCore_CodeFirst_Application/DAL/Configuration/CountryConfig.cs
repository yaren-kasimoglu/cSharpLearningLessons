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
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.CountryId);
            builder.Property(e => e.CountryName).HasMaxLength(256);

            //Seed Data =database oluştuktan sonra bu datalar otomaitkmen tablo içerisine eklensin
            builder.HasData(
            new Country() { CountryId = 1, CountryName = "Türkiye" },
            new Country() { CountryId = 2, CountryName = "Rusya" },
            new Country() { CountryId = 3, CountryName = "ABD" });
        }
    }
}

