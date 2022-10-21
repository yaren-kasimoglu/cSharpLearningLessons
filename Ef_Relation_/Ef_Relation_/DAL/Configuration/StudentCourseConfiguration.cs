using Ef_Relation_.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Configuration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            // composit primary key oluşturmamız gerekiyor
            //Composite primary key tanımlaması => Bir tabloda birden fazla PK olması

            builder.HasKey(t0 => new { t0.StudentId, t0.CourseId });


            //iki tablo birbirini tanımıyor, aradaki tablo üzerinden gideceğiz
            // studentCourse taki Course
            builder.HasOne(t0 => t0.Course).WithMany(t0 => t0.StudentCourse).HasForeignKey(t0 => t0.CourseId);
            builder.HasOne(t0 => t0.Student).WithMany(t0 => t0.StudentCourse).HasForeignKey(t0 => t0.StudentId);


            //şimdi PM ye git
        }
    }
}
