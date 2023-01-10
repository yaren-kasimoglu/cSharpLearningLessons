using System.ComponentModel.DataAnnotations;

namespace TagHelperWithHttpsConf.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
       
        [Required]
        [Display(Name ="Ürün Adı")] //Label 
        public string ProductName { get; set; }
        public bool IsDicsounted { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
