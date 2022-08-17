using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilization_Examplee.Model
{
    [Serializable] //nesne serileştirilerbilir demek. bunu vermemiz şart
    public class FormConfig
    {

        public string Text { get; set; }
        public Color  BackColor { get; set; }
        public int Widht { get; set; }
        public int Height { get; set; }


    }
}
