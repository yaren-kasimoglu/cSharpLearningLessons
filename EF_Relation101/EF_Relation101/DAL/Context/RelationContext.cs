using EF_Relation101.DAL.Configuration;
using EF_Relation101.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Relation101.DAL.Context
{
    public class RelationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // ef core un bize sağladığı db context in ayarlamalarını yaptığımız kısım 
            //db context ile alakalı ayarlamlar yapılıyor.
            //özelleştirmek gibi düşünebilirsin.
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MAKL7QI; Database=RelationsWork; Trusted_Connection=true; ");
        }

        public virtual DbSet<Order> Order{ get; set; }
        public virtual DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //db oluşmadan veya güncellenmeden önceki son müdahale edilecek ortam.
            //db özellikleri üzerindeki son güncellemeler veya verilmesi gereken tüm özelliklerin son yeri burası
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfig());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfig());

      
        }

    }
}
