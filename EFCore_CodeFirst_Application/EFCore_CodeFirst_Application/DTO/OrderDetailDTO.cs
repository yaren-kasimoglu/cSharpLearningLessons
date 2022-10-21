using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public float? Quantity { get; set; }
        public float? Discount { get; set; }
    }
}
