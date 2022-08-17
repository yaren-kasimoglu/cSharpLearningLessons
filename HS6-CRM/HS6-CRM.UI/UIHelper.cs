using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HS6_CRM.UI
{
    public class UIHelper
    {
        public const string appNAme = "CRM";
        public static DialogResult ErrorMessage(string message)
        {
            return MessageBox.Show(message,appNAme,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
