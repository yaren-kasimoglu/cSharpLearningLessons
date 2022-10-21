using EF_Core_Change_Tracking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Change_Tracking.DAL.Context
{
    public class BlogContext:DbContext

    {

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=BlogDB; Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasKey(t => t.Id);
            modelBuilder.Entity<Blog>().Property(t => t.Name).HasMaxLength(255);

            modelBuilder.Entity<Post>().HasKey(t => t.Id);
            modelBuilder.Entity<Post>().Property(t => t.Title).HasMaxLength(100);
            modelBuilder.Entity<Post>().Property(t => t.Content).HasMaxLength(5000);

            modelBuilder.Entity<Post>().HasOne(t => t.Blog).WithMany(t => t.Posts).HasForeignKey(t => t.BlogId);
        }
    }
}
