using Serilization_Examplee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Serilization_Examplee
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        List<Currency> kurlar = new List<Currency>();
        private void button1_Click(object sender, EventArgs e)
        {
            kurlar.Clear();
           
            var xml=textBox1.Text;
            XmlTextReader reader;
            try
            {
                reader = new XmlTextReader(xml);
                while (reader.Read())//okumak için bir sonraki satır var mı?
                {
                    var kur=new Currency();
                    if (reader.Name=="CurrencyName")
                    {
                        kur.CurrencyName = reader.ReadString();

                    }
                    else if (reader.Name== "ForexBuying")
                    {
                        kur.ForexBuying = Convert.ToDecimal(reader.ReadString());
                    }
                    else if (reader.Name== "ForexSelling")
                    {
                        kur.ForexSelling= Convert.ToDecimal(reader.ReadString());
                    }
                    kurlar.Add(kur);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

         private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in kurlar)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
