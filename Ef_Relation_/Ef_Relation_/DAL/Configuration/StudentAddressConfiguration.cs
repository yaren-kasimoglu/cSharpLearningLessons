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
    public class StudentAddressConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.HasKey(sa => sa.StudentAddressId);
            builder.Property(sa => sa.Country).HasMaxLength(255);
            builder.Property(sa => sa.City).HasMaxLength(255);
        }
    }
}
