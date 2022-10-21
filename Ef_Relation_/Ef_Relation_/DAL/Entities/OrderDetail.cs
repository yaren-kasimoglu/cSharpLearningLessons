using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }   //Bire-çok olduğu için foreign key burası olamaz.
        public int? ProductId { get; set; }
        public decimal Price { get; set; }
        public float? Quantity { get; set; }
        public float? Discount { get; set; }

        //bire çok ilişki için detay tablosunda bir tane foreign key column u olur 
        public int OrderId { get; set; } //Foreign Key column 
        public virtual Order Order { get; set; } //navigation property  //çektiğim oprder detail hanfgi order bilgisinin detayı olduğunu bilmek için veririz
    
     }
}
