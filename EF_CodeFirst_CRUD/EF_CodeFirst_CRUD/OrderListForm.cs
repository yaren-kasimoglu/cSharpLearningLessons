using EF_CodeFirst_CRUD.DAL.Context;
using EF_CodeFirst_CRUD.DAL.Entities;
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
    public partial class OrderListForm : Form
    {
        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            FillOrders();
        }

        private void FillOrders()
        {
            using (CrmContext db = new CrmContext())
            {
                var result = db.Order.ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            var form = new OrderForm();
            form.ShowDialog();
            FillOrders();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                var order = (dataGridView1.DataSource as List<Order>)[e.RowIndex];

                if (order!=null)
                {
                    var form = new OrderForm();
                    form.Tag = order.OrderId;
                    form.ShowDialog();
                    FillOrders();
                }
            }
        }
    }
}
