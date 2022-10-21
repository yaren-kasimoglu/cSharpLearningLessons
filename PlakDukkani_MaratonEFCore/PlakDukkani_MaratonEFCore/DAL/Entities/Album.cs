using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani_MaratonEFCore.DAL.Entities
{
    public class Album
    {

        public int AlbumId { get; set; }
        public string AlbumAdi { get; set; }
        public DateTime? CikisTarihi { get; set; }
        public decimal Fiyati { get; set; }
        public decimal? IndirimOrani { get; set; }
        public bool DevamDurumu { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
