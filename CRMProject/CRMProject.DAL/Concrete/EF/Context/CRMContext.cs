using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.DAL.Concrete.EF.Context
{
    using CRMProject.DAL.Concrete.EF.Configuration;
    using CRMProject.Entities.Abstract;
    using Entities.Concrete;

    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Kullanıcı Tablosu
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
        public override int SaveChanges()
        {
            //db deki kaydı güncelleme işlemi yaptığımızda db ye düşecek güncelleme tarihi. 
            var entitiesUpdate = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified).ToList();
            if (entitiesUpdate != null)
            {
                if (entitiesUpdate.Count>0)
                {
                    foreach (var item in entitiesUpdate)
                    {
                        ((BaseEntity)item.Entity).ModifiedDate = DateTime.Now;
                    }
                }
            }

            //db ye yeni kayıt eklendiğinde db ye düşecek kayıt tarihi
            var entitiesNewRecord = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && x.State == EntityState.Added).ToList();
            if (entitiesNewRecord != null)
            {
                if (entitiesNewRecord.Count > 0)
                {
                    foreach (var item in entitiesNewRecord)
                    {
                        ((BaseEntity)item.Entity).RecordDate = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();

        }
    }
}
