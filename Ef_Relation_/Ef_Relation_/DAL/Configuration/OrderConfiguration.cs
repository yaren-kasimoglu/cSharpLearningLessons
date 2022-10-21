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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        //  Bu kısımda istediğin müdahaleyi yapabilirsin.
        // Müdahale yapmazsan default alır. müdahale yaparsan istediğin gibi değiştirebilirsin.
        // Mesela burada OrderId benzersin olsun yazdık ve OrderNumber max 50 karakter olsun yazdık.
        // İstersen diğer kolonlarada müdahale edilebilir. İstersen müdahale etmezsin default alır direk.

        // configure ediyoruz yani
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(t0 => t0.OrderId);
            builder.Property(t0 => t0.OrderNumber).HasMaxLength(50);
            //  builder.Property(t0 => t0.OrderDate).HasColumnName("Sipariş Tarihi");    bu tablonun ismini değiştirebilirsin istersen

            //relation 
            // Order tablosunda bulunan navigation property üstünden yola çıakrak order detail tablosu ile bire çok ilişki kurgulandı.

            //HasMany => çokluk anlamında
            //WithOne => Teklik anlamında
            //Bir siparişin birden fazla detayı olabilir  -  Bir detayın tek bir siparişi oalbilir.
            //order detail tablosundaki orderıd foreign key kolonudur.

            builder.HasMany(t0 => t0.OrderDetail).WithOne(t0 => t0.Order).HasForeignKey(t0 => t0.OrderId);
        }
    }
}
