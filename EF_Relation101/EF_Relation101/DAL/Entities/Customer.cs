using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Relation101.DAL.Entities
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>(); //null ref ex almamak için.  eğer henüz oluşmadıysa sipariş, boş sipariş oluştururuz.
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string? Address { get; set; }


        public virtual List<Order> Orders { get; set; } //çok sipariş : bu yüzden koleysiyon
    }
}
