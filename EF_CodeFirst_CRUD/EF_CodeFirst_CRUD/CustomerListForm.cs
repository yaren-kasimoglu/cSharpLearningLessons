using EF_CodeFirst_CRUD.DAL.Context;
using EF_CodeFirst_CRUD.DAL.Entities;

namespace EF_CodeFirst_CRUD
{
    public partial class CustomerListForm : Form
    {
        public CustomerListForm()
        {
            InitializeComponent();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ShowCustomerForm(0);
            FillCustomer();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        private void FillControl()
        {
            FillCustomer();
        }

        private void FillCustomer()
        {
            using (CrmContext db = new CrmContext())
            {
                var result = db.Customer.ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var customerList = (dataGridView1.DataSource as List<Customer>)[e.RowIndex];
          

            if (customerList!=null)
            {
                    ShowCustomerForm(customerList.CustomerId);
                    FillCustomer();
            }
            }
        }

        private void ShowCustomerForm(int customerId)
        {
            var form = new CustomerForm();
            form.Tag = customerId;
            form.ShowDialog();
        }
    }
}