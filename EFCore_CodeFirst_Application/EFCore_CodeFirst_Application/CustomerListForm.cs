using EFCore_CodeFirst_Application.DAL.Context;
using EFCore_CodeFirst_Application.DAL.Entities;

namespace EFCore_CodeFirst_Application
{
    public partial class CustomerListForm : Form
    {
        public CustomerListForm()
        {
            InitializeComponent();
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
            using (CrmContext db=new CrmContext())
            {
                var result = db.Customer.ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;
            }
        }

        private void  ShowCustomerForm(int customerID)
        {
            var form= new CustomerForm();
            form.Tag = customerID;
            form.ShowDialog();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            ShowCustomerForm(0);
            FillCustomer();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var customerList = (dataGridView1.DataSource as List<Customer>)[e.RowIndex];
            if (customerList != null)
            {
                ShowCustomerForm(customerList.CustomerId);
                FillCustomer();

            }
        }
    }
}