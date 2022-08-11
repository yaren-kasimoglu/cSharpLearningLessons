using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loose_Coupling_Example
{
    public class YPKrediKartı : ICreditCard
    {
        public string Pay(decimal amount)
        {
            return $"Yapı Kredi ödemesi {amount} olarak alınmıştır";
        }
    }
}
