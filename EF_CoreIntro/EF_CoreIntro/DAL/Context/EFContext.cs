using EF_CoreIntro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CoreIntro.DAL.Context
{
    public class EFContext : DbContext //veritabanına karşılık geliyor olacak. db context ten kalıtım almamız gerekiyor
    {

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }


        // EF Context configure ayarın yapıldığı methoddur. Bize configurasyon için optionsBuilder parametresi gönderilir. Bu parametre üstünden ayarlamalar yapılabilir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MAKL7QI; Database=Northwind; Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasKey(e =>
                        e.EmployeeID); // TABLODAKİ PRİMARY KEY COLONU BUDUR DEMEK

            modelBuilder.Entity<Categories>().HasKey(e => e.CategoryID);

            modelBuilder.Entity<Customers>().HasKey(e => e.CustomerID);

            modelBuilder.Entity<Products>().HasKey(e => e.ProductID);

            modelBuilder.Entity<Shippers>().HasKey(e => e.ShipperID);
        
        }
        

    }
}
