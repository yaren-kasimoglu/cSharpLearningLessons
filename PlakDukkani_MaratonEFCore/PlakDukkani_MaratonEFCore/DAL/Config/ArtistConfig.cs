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
    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ArtistName).HasMaxLength(255);

            builder.HasData(

                new Artist() { Id=1, ArtistName= "Nina Simone", AlbumId=1 },
                new Artist() { Id=2, ArtistName= "Edith Piaf" , AlbumId=2},
                new Artist() { Id=3, ArtistName= "Cyndi Lauper",AlbumId=3 },
                new Artist() { Id=4, ArtistName= "Various Artists", AlbumId=4 },
                new Artist() { Id=5, ArtistName= "Fazıl Say", AlbumId=5 }

                );
        }
    }
}
