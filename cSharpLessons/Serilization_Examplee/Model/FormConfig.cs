using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serilization_Examplee.Model
{
    [Serializable] //nesne serileştirilerbilir demek. bunu vermemiz şart
    public class FormConfig
    {

            public string Text { get; set; }
            public ConsoleColor BagColor { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public FormBorderStyle borderStyle { get; set; }
        }
    }