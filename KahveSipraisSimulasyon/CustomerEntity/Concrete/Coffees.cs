using CustomerEntity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerEntity.Concrete
{
    public class Coffees:IOrders
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double PreparationTime { get; set; }
        public int Score { get; set; }

    }
}
