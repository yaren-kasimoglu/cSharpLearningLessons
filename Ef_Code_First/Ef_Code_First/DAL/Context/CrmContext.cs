using Ef_Code_First.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Code_First.DAL.Context
{
    public class CrmContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection strginf tanımlaması ayarlanabilir
            optionsBuilder.UseSqlServer("Server=DESKTOP-MAKL7QI; Database=CodeFirstDb; Trusted_Connection=true;");//yeni bir db inşa ediyor kod tarafında CodeFirstDb Adında

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //db güncellenmeden veya oluşturulmadan önbce çalışır.db ile alakalı tüm işlemleri burada vgerçekleştirebileceğiz

            modelBuilder.Entity<Customer>().HasKey(c=>c.CustomerId); //primary key alanını customer id yap
            modelBuilder.Entity<Customer>().Property(c => c.CustomerName).HasMaxLength(255).IsRequired(true); //boş geçilemez
            modelBuilder.Entity<Customer>().Property(c => c.Email).HasMaxLength(255);
            modelBuilder.Entity<Customer>().Property(c => c.CustomerCode).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.Phone).HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(1000);

            base.OnModelCreating(modelBuilder);
        }
        public virtual  DbSet<Customer> Customer { get; set; }
    }
}
