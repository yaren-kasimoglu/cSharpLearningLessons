using Linq_Example2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Example2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        private void FillControl()
        {
            FillPersonal();
            FillCustomer();
            FillShipVia();
        }

        private void FillShipVia()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Shippers.Select(s => new { Name = s.CompanyName, Id = s.ShipperId }).ToList();
                cmbShipVia.DisplayMember = "Name";
                cmbShipVia.ValueMember = "Id";

                cmbShipVia.DataSource = result;
            }
        }

        private void FillCustomer()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Customers.Select(c => new { Name = c.CompanyName, Id = c.CustomerId }).ToList();
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "Id";

                cmbCustomer.DataSource = result;
            }
        }

        private void FillPersonal()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Employees.Select(e => new { Name = e.FirstName + " " + e.LastName, Id = e.EmployeeId }).ToList();
                cmbPersonal.DisplayMember = "Name"; //ekranda gözükecek
                cmbPersonal.ValueMember = "Id"; // seçilen elemanın value deeğeri arka tarafta tutması için verilern değer


                cmbPersonal.DataSource = result; ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillSearch();
        }

        private void FillSearch()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var query = db.Orders.AsQueryable();

                if (cmbPersonal.SelectedIndex > -1)
                {
                    int selectedPersonalId = Convert.ToInt32(cmbPersonal.SelectedValue);
                    query = query.Where(e => e.EmployeeId == selectedPersonalId).AsQueryable();
                }
                if (cmbCustomer.SelectedIndex > -1)
                {
                    string selectedCustomerId = Convert.ToString(cmbPersonal.SelectedValue);
                    query = query.Where(c => c.CustomerId == selectedCustomerId).AsQueryable();
                }
                if (cmbShipVia.SelectedIndex > -1)
                {
                    int selectedShipViaId = Convert.ToInt32(cmbPersonal.SelectedValue);
                    query = query.Where(s => s.EmployeeId == selectedShipViaId).AsQueryable();
                }

                var result = query.ToList();
                dataGridView1.DataSource = result;


            }
        }

    }
}
