using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static_Example
{
    //class static olursa içi de static olmalıdır.
    //class non sttaic olursa içinde hem static hem non static bulunabilir
    public static class Customer
    {

        private static int id;

        public static string Name { get; set; }

        public static void Add()
        {

        }
    }
}
