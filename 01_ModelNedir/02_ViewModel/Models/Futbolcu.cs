namespace _02_ViewModel.Models
{
    public class Futbolcu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Team TeamId { get; set; }
        public Mevki MevkiId { get; set; }
    }
}
