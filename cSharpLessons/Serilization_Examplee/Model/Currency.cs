using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilization_Examplee.Model
{
    public class Curency
    {
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }

        public override string ToString()
        {
            return $"{CurrencyName} Alış={ForexBuying}  Satış={ForexSelling}";
        }
    }
}