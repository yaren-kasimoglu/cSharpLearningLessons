using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumOrnek
{

    public enum Departman
    {
        Yazilim,Sistem_Ag_Uzamanligi,Grafik_Tasarim,Ingilizce,Muhasebe
    }
    public class Personel
    {
        public string AdiSoyadi { get; set; }
        public Departman Departman { get; set; }
    }
}
