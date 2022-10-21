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
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillGridLayout();
            FillProduct();

        }

        private void FillProduct()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var products = db.Products.ToList();
                dataGridViewProduct.DataSource = products;
            }
        }

        private void FillGridLayout()
        {
            dataGridViewProduct.AutoGenerateColumns = false;
            dataGridViewProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

           
            dataGridViewProduct.Columns.Add(GenerateColumn("ProductName", "Adı"));
            dataGridViewProduct.Columns.Add(GenerateColumn("SupplierId", "Tedarikçi Adı"));
            dataGridViewProduct.Columns.Add(GenerateColumn("CategoryId", "Kategori"));
            dataGridViewProduct.Columns.Add(GenerateColumn("QuantityPerUnit", "Birim Adet"));
            dataGridViewProduct.Columns.Add(GenerateColumn("UnitPrice", "Birim Fiyat"));
            dataGridViewProduct.Columns.Add(GenerateColumn("UnitsInStock", "Stok Adet"));
            dataGridViewProduct.Columns.Add(GenerateColumn("UnitsOnOrder", "Sipariş Adet"));
            dataGridViewProduct.Columns.Add(GenerateColumn("ReorderLevel", "Level"));
            dataGridViewProduct.Columns.Add(GenerateColumn("Discontinued", "Devam Durum"));
        }

        public DataGridViewColumn GenerateColumn(string name, string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName = name;
            column.HeaderText = caption;
            return column;
        }

        
        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }

            int productId=((dataGridViewProduct.DataSource as List<Product>)[e.RowIndex].ProductId);
            var form = new ProductForm();
            form.Tag = productId;
            form.ShowDialog();
            FillProduct();
        }
    }
}
