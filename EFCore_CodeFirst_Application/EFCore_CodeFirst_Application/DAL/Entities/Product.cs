using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Entities
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
