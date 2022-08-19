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
    using Model;
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            kurlar.Clear();
           
            var xml=textBox1.Text;
            XmlTextReader reader;

            string currencyName = ""; string forexBuying = ""; string forexSelling = "";

            try
            {
                reader = new XmlTextReader(xml);
                while (reader.Read())//okumak için bir sonraki satır var mı?
                {


                    if (reader.Name == "CurrencyName")
                    {
                        currencyName = reader.ReadString();

                    }
                    else if (reader.Name == "ForexBuying")
                    {
                        forexBuying = reader.ReadString();

                    }
                    else if (reader.Name == "ForexSelling")
                    {
                        forexSelling = reader.ReadString();
                    }
                    if (!string.IsNullOrWhiteSpace(forexBuying) && !string.IsNullOrWhiteSpace(forexSelling))
                    {
                        var kur = new Currency();
                        kur.CurrencyName = currencyName;
                        kur.ForexBuying = Convert.ToDecimal(forexBuying.Replace(".", ","));
                        kur.ForexSelling = Convert.ToDecimal(forexSelling.Replace(".", ","));
                        kurlar.Add(kur);

                        currencyName = "";
                        forexBuying = "";
                        forexSelling = "";

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            listBoxRefresh();

        }

        private void listBoxRefresh()
        {
            listBox1.Items.Clear();
            foreach (var item in kurlar)
            {
                listBox1.Items.Add(item);
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
