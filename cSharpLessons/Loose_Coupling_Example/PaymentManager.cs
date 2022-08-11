using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loose_Coupling_Example
{
    public class PaymentManager
    {
        //Bir nesne veya kod aparçacığı çalışmak için başka nesnelere ihtiyaç duyuyor ise buna Tightly Coupled Systems: Sıkı bağlı sistemler denir

        private ICreditCard _creditCard;

        public PaymentManager(ICreditCard card)
        {
            _creditCard = card; 
        }

        public string GetPaid(decimal amount)
        {
            
            return _creditCard.Pay(amount);
        }

    }
}
