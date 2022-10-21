using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_CRUD
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuCustomerListItem_Click(object sender, EventArgs e)
        {
            var form=new CustomerListForm();
            form.ShowDialog();
        }

        private void menuProductListItem_Click(object sender, EventArgs e)
        {
           CreateForm<ProductListForm>().ShowDialog();
        }

        private void menuOrderListItem_Click(object sender, EventArgs e)
        {
            CreateForm<OrderListForm>().ShowDialog();
        }

        public T CreateForm<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
