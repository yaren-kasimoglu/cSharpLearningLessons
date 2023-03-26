using HS7_BP.Domain.Entities;
using HS7_BP.Domain.Entities.Abstract;
using HS7_BP.Infrastructure.EntityMapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Infrastructure.DataAccess
{
    public class BlogumDbContext : IdentityDbContext<AppUser>
    {
        public BlogumDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entity = ChangeTracker.Entries<IBaseEntity>();
            foreach (var item in entity)
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.Now;
                    item.Entity.CreatedBy = "Admin";
                    item.Entity.Status = Domain.Enums.Status.Active;
                }
                else if (item.State == EntityState.Modified || item.State == EntityState.Deleted)
                {

                    item.Entity.ModifiedDate = DateTime.Now;
                    item.Entity.ModifiedBy = "Admin";

                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        //    //builder.Entity<Category>().Property(x => x.Name).IsRequired().HasMaxLength(55);


        //    //oluşturduğumuz Mapping classlarını aşağıdaki gibi contextin kullanımına açarız.
         builder.ApplyConfiguration(new AppUserMapping());
         builder.ApplyConfiguration(new CategoryMapping());

          base.OnModelCreating(builder);
        }
    }
}
