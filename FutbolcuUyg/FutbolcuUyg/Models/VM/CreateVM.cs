namespace FutbolcuUyg.Models.VM
{
    public class CreateVM
    {
        public Futbolcu Futbolcu { get; set; }
        public List<Mevki> Mevki { get; set; }
        public List<Takim> Takim { get; set; }
    }
}
