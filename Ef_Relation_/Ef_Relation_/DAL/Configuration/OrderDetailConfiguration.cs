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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        void IEntityTypeConfiguration<OrderDetail>.Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(t0 => t0.OrderDetailId);
        }
    }
}
