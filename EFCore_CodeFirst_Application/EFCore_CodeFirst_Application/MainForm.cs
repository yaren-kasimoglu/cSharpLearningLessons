using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCore_CodeFirst_Application
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuCustomerListItem_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            form.ShowDialog();
        }

        private void menuProductListItem_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            form.ShowDialog();
        }

        private void menuOrderListItem_Click(object sender, EventArgs e)
        {
            var form=new OrderForm();
            form.ShowDialog();
        }
    }
}
