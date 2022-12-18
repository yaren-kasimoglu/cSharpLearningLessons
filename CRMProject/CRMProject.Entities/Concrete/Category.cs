using CRMProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProject.Entities.Concrete
{
    public class Category:BaseEntity
    {
        public Category()
        {
          this.Products = new List<Product>();   
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual  ICollection<Product> Products { get; set; }
    }
}
