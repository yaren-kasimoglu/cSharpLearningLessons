using BlogProject.Core.Entity.Map;
using BlogProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities.Map
{
    public class CategoryConfiguration:CoreConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.CategoryName).HasMaxLength(255).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired(false);
            base.Configure(builder);
        }
    }
}
