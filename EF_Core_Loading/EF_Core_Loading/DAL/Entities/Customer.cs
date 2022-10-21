using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Loading.DAL.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}
