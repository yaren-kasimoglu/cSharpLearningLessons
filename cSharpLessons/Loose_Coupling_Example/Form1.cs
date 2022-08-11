using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loose_Coupling_Example
{
    public partial class Form1 : Form
    {

        //loose copuling : gevşek bağımlılık ilkesi

        //sıkı bağımlılık

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreditCard creditCard = new CreditCard();
            YPKrediKartı yPKrediKartı=new YPKrediKartı();
            PaymentManager paymentManager = new PaymentManager(yPKrediKartı); //çalışması için kredi kartına ihtiyaç duyuyor. sıkı bağımlılık vardır

           string result= paymentManager.GetPaid(250);
            MessageBox.Show(result);

        }
    }
}
