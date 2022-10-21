using EF_CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CRUD
{
    public partial class SupplierList : Form
    {
        public SupplierList()
        {
            InitializeComponent();
        }

        private void SupplierList_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillGridLayout();
            FillSupplier();
        }

        private void FillSupplier()
        {
            using (NorthwindContext db=new NorthwindContext())
            {
                var suppliers = db.Suppliers.ToList();
                dataGridView1.DataSource = suppliers;
            }
        }

        private void FillGridLayout()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode=System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(GenerateColumn("CompanyName","Tedarikçi Adı"));
            dataGridView1.Columns.Add(GenerateColumn("ContactName", "İletişim Kurulan Kişi"));
            dataGridView1.Columns.Add(GenerateColumn("ContactTitle", "İletişim Kurulan Kişşi Ünvanı"));
        }

        public DataGridViewColumn GenerateColumn(string name,string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName= name;
            column.HeaderText = caption;
            return column;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }

            var supplierId = ((dataGridView1.DataSource as List<Supplier>)[e.RowIndex]).SupplierId;
            var form = new SupplierForm();
            form.Tag = supplierId;
            form.ShowDialog();
            FillSupplier();
        }

     
    }
}
