using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Relation101.DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } // bir müşteri
    }
}
