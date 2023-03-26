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
    public class PostMapping:BaseEntityMapping<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).HasColumnType("varchar").HasMaxLength(500);
            builder.Property(x => x.Content).HasColumnType("varchar").HasMaxLength(10000);
            builder.Property(x => x.Summary).HasColumnType("varchar").HasMaxLength(2500);
            builder.Property(x => x.MinRead).HasColumnType("varchar").HasMaxLength(25);

            base.Configure(builder);
        }
    }
}
