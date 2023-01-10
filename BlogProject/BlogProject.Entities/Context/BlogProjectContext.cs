using BlogProject.Core.Entity;
using BlogProject.Entities.Entities;
using BlogProject.Entities.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities.Context
{
    public class BlogProjectContext : DbContext
    {
        public BlogProjectContext(DbContextOptions<BlogProjectContext> options):base()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=HS6BlogProject; Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Environment.MachineName;
            string ipAddres = "127.0.0.1";
            DateTime date = DateTime.Now;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (entity != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIP = ipAddres;
                            entity.CreatedDate = date;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIP = ipAddres;
                            entity.ModifiedDate = date;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
