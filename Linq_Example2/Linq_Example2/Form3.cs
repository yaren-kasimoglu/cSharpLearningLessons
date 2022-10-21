using Linq_Example2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Example2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FillForm();

        }

        private void FillForm()
        {
            FillCategory();
            FillSupplier();
        }

        private void FillSupplier()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Suppliers.Select(s => new { Name = s.CompanyName, Id = s.SupplierId }).ToList();
                cmbSupplier.DisplayMember = "Name";
                cmbSupplier.ValueMember = "Id";

                cmbSupplier.DataSource = result;
            }
        }

        private void FillCategory()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Categories.Select(s => new { Name = s.CategoryName, Id = s.CategoryId }).ToList();
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";

                cmbCategory.DataSource = result;
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
                var query = db.Products.AsQueryable();

                if (cmbSupplier.SelectedIndex > -1)
                {
                    int selectedSupplierId = Convert.ToInt32(cmbSupplier.SelectedValue);
                    query = query.Where(s => s.SupplierId == selectedSupplierId).AsQueryable();
                }
                if (cmbCategory.SelectedIndex > -1)
                {
                    int selectedCategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                    query = query.Where(c => c.CategoryId == selectedCategoryId).AsQueryable();
                }
            

                var result = query.ToList();
                dataGridView1.DataSource = result;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
        }
    }
}
