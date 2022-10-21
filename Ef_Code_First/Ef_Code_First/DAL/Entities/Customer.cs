using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Code_First.DAL.Entities
{
   // [Table("Musteri")]
    public class Customer
    {
      //  [Key]
        public int CustomerId { get; set; }
      //  [StringLength(255)]
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
    }
}
