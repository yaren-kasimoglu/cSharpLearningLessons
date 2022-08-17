using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Generic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Generic

        /*
         Genericler bir class ı bir tür üstüne değil de birden çok tür e destek verebilecek şekilde yazmamıza olanak sağlayan yapılardır
        Asıl amaç birden fazla türe destek verebilmek  

        //Generic class lara birden fazla tip de gönderebilriz<t, t1,t2,t3> gibi. bu durumda da nesneyi üretirken bu gönderdiğimiz tiplerde veri alabiliriz.
         
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            //ArrayList ler generic değildir. object çağırırız ve convert yapmamız gerekir

            //GenericTestClass<string> testClass = new GenericTestClass<string>();

            //GenericTestClass<int> testClass2 = new GenericTestClass<int>();

           
            GenericTestClass<int,float,string,decimal> test = new GenericTestClass<int, float, string, decimal>();
        }
    }
}
