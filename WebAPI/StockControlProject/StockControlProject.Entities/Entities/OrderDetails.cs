﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControlProject.Entities.Entities
{
    public class OrderDetails:BaseEntity
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }


        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
