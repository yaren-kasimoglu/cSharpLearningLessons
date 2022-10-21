using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani_MaratonEFCore.DAL.Config
{
    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(a => a.AlbumId);

            builder.Property(a => a.AlbumAdi).HasMaxLength(255);

            builder.HasOne(x => x.Artist).WithMany(x => x.Albums).HasForeignKey(x => x.ArtistId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(

                new Album() {AlbumId=1,AlbumAdi= "The Nina Simone Collection Plak", CikisTarihi=DateTime.Now, Fiyati=223.20m, IndirimOrani=0, DevamDurumu=true, ArtistId=1  },
                new Album() {AlbumId=2,AlbumAdi= "Edith Piaf La Vie En Rose Plak", CikisTarihi=DateTime.Now, Fiyati=172.00m, IndirimOrani=0.5m, DevamDurumu=false, ArtistId=2  },
                new Album() {AlbumId=3,AlbumAdi= "Cyndi Lauper She'S So Unusual Plak", CikisTarihi=DateTime.Now, Fiyati=369.60m, IndirimOrani=0.75m, DevamDurumu=false, ArtistId=3  },

                new Album() {AlbumId=4,AlbumAdi= "Various Artists The Very Best of Jazz Love Songs Plak", CikisTarihi=DateTime.Now, Fiyati=175.20m, IndirimOrani=0, DevamDurumu=false, ArtistId=4  },
                new Album() {AlbumId=5,AlbumAdi= "Şu Dünyanın Sırrı", CikisTarihi=DateTime.Now, Fiyati=22.50m, IndirimOrani=0, DevamDurumu=true, ArtistId=5  },
                new Album() {AlbumId=6,AlbumAdi= "Akılla Bir Konuşmam Oldu", CikisTarihi=DateTime.Now, Fiyati=14.90m, IndirimOrani=0, DevamDurumu=true, ArtistId=5  }


            );
        }
    }
}
