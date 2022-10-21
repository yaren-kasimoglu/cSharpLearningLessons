using System.ComponentModel.DataAnnotations;


namespace WebApplication3.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]

        public string Description { get; set; } = default;
    }
}
