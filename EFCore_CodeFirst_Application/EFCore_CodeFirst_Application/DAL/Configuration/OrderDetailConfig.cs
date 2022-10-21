using EFCore_CodeFirst_Application.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Configuration
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.OrderDetailId);

            builder.HasOne(x=>x.Order).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.Restrict);
             
            
            builder.HasOne(x=>x.Product).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
