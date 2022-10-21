using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_CRUD.DAL.Entities
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails=new List<OrderDetail>();
        }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }

        //bir ürün birdene fazla sipariş içerisinde geçebilir
        public  List<OrderDetail> OrderDetails { get; set; }
    }
}
