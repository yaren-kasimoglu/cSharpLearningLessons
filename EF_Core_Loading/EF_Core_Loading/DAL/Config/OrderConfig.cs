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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.HasKey(t => t.OrderId);
            builder.Property(t => t.OrderNumber).HasMaxLength(255);

            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);

            builder.HasData(

                new Order() { CustomerId = 1, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000001", OrderId = 1, RecordDate = DateTime.Now },
                new Order() { CustomerId = 1, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000002", OrderId = 2, RecordDate = DateTime.Now },
                new Order() { CustomerId = 1, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000003", OrderId = 3, RecordDate = DateTime.Now },

                new Order() { CustomerId = 2, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000004", OrderId = 4, RecordDate = DateTime.Now },
                new Order() { CustomerId = 2, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000005", OrderId = 5, RecordDate = DateTime.Now },
                new Order() { CustomerId = 2, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000006", OrderId = 6, RecordDate = DateTime.Now },

                new Order() { CustomerId = 3, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000007", OrderId = 7, RecordDate = DateTime.Now },
                new Order() { CustomerId = 3, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000008", OrderId = 8, RecordDate = DateTime.Now },
                new Order() { CustomerId = 3, ModifiedDate = DateTime.Now, OrderDate = DateTime.Now, OrderNumber = "50000009", OrderId = 9, RecordDate = DateTime.Now });

        }
    }
}
