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
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.CustomerName = "Yarem";
            customer.Adres = "İzmit";


        }
    }
}
