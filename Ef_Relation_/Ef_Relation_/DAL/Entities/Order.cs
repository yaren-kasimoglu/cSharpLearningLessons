using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    public class Order
    {
        public Order()
        {
            this.OrderDetail=new List<OrderDetail>(); //null ref exception ile karşılaşmamak için bunu ekliyoruz
        }
        public int OrderId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }


        public virtual List<OrderDetail> OrderDetail { get; set; }
    }
}
