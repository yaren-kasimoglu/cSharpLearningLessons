using _01_ModelNedir.Models.Enums;

namespace _01_ModelNedir.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public DateTime BirthDate { get; set; }
        public WorkingType WorkingType { get; set; }
    }
}
