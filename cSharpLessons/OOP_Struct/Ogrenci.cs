using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Struct
{
    //Struct: Yapı: Birbiri ile ile ilişkili değerleri bir arada tutmak için kullanılan yapılardır.
    //default ctor yazılmak istendiğnde derleyici hatası alır. Ancak içerisinde yazan fields ve propertyleri ctor içerisinde kullanırsak ctor desteği verebiliriz. Defaultta hata alırız.
    //Structlar kalıtım almazlar 
    //Structlar kalıtım veremez
   

    public struct Ogrenci
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string No { get; set; }
    }
}
