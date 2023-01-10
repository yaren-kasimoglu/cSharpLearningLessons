using Blog_MVC.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DAL.Concrete.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleId);
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(2500);
        }
    }
}
