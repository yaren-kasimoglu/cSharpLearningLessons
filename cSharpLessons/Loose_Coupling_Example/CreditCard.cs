using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loose_Coupling_Example
{
    public class CreditCard:ICreditCard
    {
        public string Pay(decimal amount)
        {
            //ödeme yapışıyor

            return $"Ödeme {amount} olarak alınmıştır";
        }

    }
}
