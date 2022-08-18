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

namespace Serilization_Examplee
{
    public partial class Form2 : Form
    {
        Customer customer = new Customer();
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            customer.Id = 1;
            customer.CustomerName = "Yaren";
            customer.Adres = "İzmit";

            string jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
            txtJson.Text = jsonValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jsonValue = txtJson.Text;
            var customer = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(jsonValue);
        }
    }
}
