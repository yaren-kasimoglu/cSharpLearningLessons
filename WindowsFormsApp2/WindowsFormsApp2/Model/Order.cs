using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public class Order
    {
        /// <summary>
        /// sıcak -soğuk kagveler isimleri
        /// </summary>
        public Product HotCoffee { get; set; }
    
        public Product ColdCoffee { get; set; }
 
        /// <summary>
        /// soğuk -sıcak süt seçimi
        /// </summary>
        public short Milk { get; set; }



    }
}
