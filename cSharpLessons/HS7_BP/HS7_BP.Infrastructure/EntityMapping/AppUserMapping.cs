using HS7_BP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Infrastructure.EntityMapping
{
    public class AppUserMapping : BaseEntityMapping<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Address).IsRequired(false).HasMaxLength(1000).HasColumnType("varchar");
            builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(20).HasColumnType("varchar");

            base.Configure(builder);
        }

    }
}
