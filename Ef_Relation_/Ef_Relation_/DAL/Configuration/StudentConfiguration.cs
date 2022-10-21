using Ef_Relation_.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s=>s.StudentId);
            builder.Property(s => s.FirstName).HasMaxLength(255);
            builder.Property(s => s.LastName).HasMaxLength(255);
            builder.Property(s => s.Email).HasMaxLength(500);
            builder.Property(s => s.Phone).HasMaxLength(50);

            //Bire bir ilişki verebilmek için
            //Student tablosu ile Student Address tablosu navigatioın propertler üstünde ilişkilidir şeklinde yazdık ve foreign key tanımlamasını da söyledik.

            builder.HasOne(s => s.StudentAddress).WithOne(s => s.Student).HasForeignKey<StudentAddress>(s => s.StudentAddressId);
        }
    }
}
