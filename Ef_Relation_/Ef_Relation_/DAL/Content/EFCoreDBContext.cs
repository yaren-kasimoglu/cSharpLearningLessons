using Ef_Relation_.DAL.Configuration;
using Ef_Relation_.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Content
{
    public class EFCoreDBContext:DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAddress> StudentAddress { get; set; }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<StudentCourse> StudentCourse { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MAKL7QI; Database=Relation;Trusted_Connection=true; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Bu ayarları git Configuration un altındaki class lardan al. Kod kalabalığı olmasın diye yapıyruz

            modelBuilder.ApplyConfiguration<Student>(new StudentConfiguration());
            modelBuilder.ApplyConfiguration<StudentAddress>(new StudentAddressConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<OrderDetail>(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration<Course>(new CourseConfiguration());
            modelBuilder.ApplyConfiguration<StudentCourse>(new StudentCourseConfiguration());


            /// burdan sonra PM ye git   PM> add-migration onetomany_migration  yaz enter
            ///   sonrada   update-database yaz enterla
            ///   

        }
    }
}
