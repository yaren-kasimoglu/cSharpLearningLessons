using EF_CodeFirst_CRUD.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_CRUD.DAL.Configuration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x=> x.OrderId);
            builder.Property(x => x.OrderCode).HasMaxLength(250);

            //OnDeleteAction=> veri tabanında ilişkili tablolarda silme işlemi yapılması durumunda yapılacak aktiviteyi seçiyoruz.
            //db üzerinde farklı seçenekleri var.


            builder.HasOne(t=>t.Customer).WithMany(t0=>t0.Orders).HasForeignKey(t1=>t1.CustmerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
