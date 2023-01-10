using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entity.Map
{
    public abstract class CoreConfiguration<T> : IEntityTypeConfiguration<T> where T : CoreEntity //Core entity den mirass alanlar
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID); //ID kolonu identity olarak işaretlensin
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(false);
            builder.Property(x => x.CreatedComputerName).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.CreatedIP).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedComputerName).IsRequired(false).HasMaxLength(255);
            builder.Property(x => x.ModifiedIP).IsRequired(false).HasMaxLength(20);
        }
    }
}
