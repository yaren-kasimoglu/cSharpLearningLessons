using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongulerCalisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            int sayac = 0;
            int toplam = 0;

            while (sayac<=10)
            {
                toplam = toplam + sayac;
                sayac++;
            }
            label1.Text = toplam.ToString();

            //int sayac = 0;

            //while (sayac<10)
            //{
            //    listBox1.Items.Add("Deneme");
            //    sayac++;
            //}

            //int bakteri = 1;
            //for (int i = 1; i <= 24; i++)
            //{
            //    bakteri = bakteri * 2;
            //}
            //label1.Text = bakteri.ToString();


            //int fakt = 1;
            //for (int i = 1; i <=6; i++)
            //{
            //    fakt = fakt * i;
            //}

            //label1.Text = fakt.ToString();
            //int toplam = 0;

            //for (int i = 1; i <= 10; i++)
            //{
            //    toplam=toplam+i;
            //}
            //label1.Text = toplam.ToString();
        }
    }
}
