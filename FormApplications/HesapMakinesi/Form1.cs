using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HesapMakinesi
{
    public partial class Form1 : Form
    {
        double sonuc;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double sayi1 = Convert.ToInt32(txtS1.Text);
            double sayi2 = Convert.ToInt32(txts2.Text);

            sonuc = sayi1 + sayi2;

            MessageBox.Show(sonuc.ToString());


        }

        private void btnCikar_Click(object sender, EventArgs e)
        {
            double sayi1 = Convert.ToInt32(txtS1.Text);
            double sayi2 = Convert.ToInt32(txts2.Text);


            if (sayi1 > sayi2)
            {
                sonuc = sayi1 - sayi2;
            }
            else
            {
                sonuc = sayi2 - sayi1;
            }


            MessageBox.Show(sonuc.ToString());
        }

        private void btnCarp_Click(object sender, EventArgs e)
        {
            double sayi1 = Convert.ToInt32(txtS1.Text);
            double sayi2 = Convert.ToInt32(txts2.Text);

            sonuc = sayi1 * sayi2;

            MessageBox.Show(sonuc.ToString());
        }

        private void btnBol_Click(object sender, EventArgs e)
        {
            double sayi1 = Convert.ToInt32(txtS1.Text);
            double sayi2 = Convert.ToInt32(txts2.Text);

            sonuc = sayi1 / sayi2;

            MessageBox.Show(sonuc.ToString());
        }
    }
}
