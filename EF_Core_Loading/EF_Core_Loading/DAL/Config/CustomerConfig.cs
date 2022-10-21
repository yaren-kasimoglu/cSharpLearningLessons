using EF_Core_Loading.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading.DAL.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CustomerName).HasMaxLength(255);
            builder.Property(t => t.Email).HasMaxLength(255);
            builder.Property(t => t.Phone).HasMaxLength(50);

            builder.HasData(
                new Customer() { Id = 1, CustomerName = "Yaren KAsımoğlu", Email = "yk@gmail.com", ModifiedDate = DateTime.Now, Phone = "5436097030", RecordDate = DateTime.Now },
                new Customer() { Id = 2, CustomerName = "Erdi Şen", Email = "eş@gmail.com", ModifiedDate = DateTime.Now, Phone = "5436055030", RecordDate = DateTime.Now },
                new Customer() { Id = 3, CustomerName = "Yunus Emre Teke", Email = "yt@gmail.com", ModifiedDate = DateTime.Now, Phone = "5436033030", RecordDate = DateTime.Now });

        }
    }
}
