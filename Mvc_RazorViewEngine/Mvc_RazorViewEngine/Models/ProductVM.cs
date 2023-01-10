using System.Reflection.Metadata.Ecma335;

namespace Mvc_RazorViewEngine.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
