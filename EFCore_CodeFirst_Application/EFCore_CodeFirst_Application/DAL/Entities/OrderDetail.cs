using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public decimal? Price { get; set; }
        public float? Quantity { get; set; }
        public float Discount { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
