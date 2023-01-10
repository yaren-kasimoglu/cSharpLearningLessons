namespace FutbolcuUyg.Models
{
    public class Futbolcu
    {
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }
        public int MevkiId { get; set; }
        public int TakimId { get; set; }

        public Takim Takim { get; set; }
        public Mevki Mevki { get; set; }
    }
}
