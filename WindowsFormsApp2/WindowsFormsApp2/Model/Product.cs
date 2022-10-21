using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public class Product
    {
        /// <summary>
        /// ürün adı
        /// </summary>
        public string    ProductName { get; set; } 
        /// <summary>
        /// ürünün hazırlanma süresi
        /// </summary>
        public double PreparationTime { get; set; }
        /// <summary>
        /// ürünün scoru, değerlendirme puanı
        /// </summary>
        public int Score { get; set; }

        
    }
}
