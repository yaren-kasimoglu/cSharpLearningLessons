using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Entities
{
    public class Customer
    {
        public Customer()
        {
            this.Order = new List<Order>();
        }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual List<Order> Order { get; set; }
    }
}
