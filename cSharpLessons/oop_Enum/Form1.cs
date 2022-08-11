using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_Enum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Enum : kod onkunaklığını arttırmak için bazı kodlara okunaklı degerler verilebilir
        private void Form1_Load(object sender, EventArgs e)
        {
            Level sinir = Level.Medium;

            MessageBox.Show(sinir.ToString());

        }

        enum Level
        {
            //istersek bu şekilde default değerlere sahip olan değerler verebiliyoruz
            Low,
            Medium,
            High,
        }


        enum TransferType
        {
            //istersek bu şekilde değerlerini kendimiz verecek şekilde kullanabiliyoruz
            CreditCard = 2,
            eft = 5,
            swift = 7
        }
        enum Months
        {
            // değer verdikten sonrası numeric sır ile gitmeye başlar.
            //atamadan sonra değerler yapılan atamaya göre numeric sıra ile devam eder.
            January,
            February,
            March = 6,
            April,
            May,
            June

        }
    }
}
