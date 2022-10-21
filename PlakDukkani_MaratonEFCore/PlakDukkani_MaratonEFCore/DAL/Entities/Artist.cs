using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani_MaratonEFCore.DAL.Entities
{
    public class Artist
    {
        public Artist()
        {
            this.Albums = new List<Album>();
        }
        public int Id { get; set; }
        public string ArtistName { get; set; }

        public int? AlbumId { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}
