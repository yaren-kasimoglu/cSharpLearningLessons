using EF_Core_Loading.DAL.Config;
using EF_Core_Loading.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading.DAL.Context
{
    public class ExampleContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //UseLazyLoadingProxies=> devralınabilecek bütük virtual navigation propertyler için lazy loading aktif hale gelecektir. 
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-MAKL7QI; Database=ExampleDbContext; Trusted_Connection=true;");
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
        }
    }
}
