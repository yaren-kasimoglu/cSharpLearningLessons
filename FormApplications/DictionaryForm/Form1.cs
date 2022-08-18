using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<int,string> Ogrenciler=new Dictionary<int, string>();

        private void button1_Click(object sender, EventArgs e)
        {
            Ogrenciler.Add(1, "Yaren");
            Ogrenciler.Add(2, "Erdi");
            Ogrenciler.Add(3, "Taha");

           var deger= Ogrenciler[2];
            MessageBox.Show(deger);

           //8 döngüde dönerken değerini KeyValuePair şeklinde veririz
            foreach (KeyValuePair<int,string> item in Ogrenciler)
            {

            }
            
        }
    }
}
