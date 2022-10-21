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
    public partial class NorthwindMainForm : Form
    {
        public NorthwindMainForm()
        {
            InitializeComponent();
        }

        private void NorthwindMainForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        
        private void FillForm()
        {
            FillGridLayoutSupplier();
            FillSupplierTable();
            FillGridLayoutProducts();
            FillProductTable();
            FillGridLayoutCategory();
            FillCategoryTable();
            FillGirdLayoutEmployee();
            FillEmployeeTable();
        }

        /// <summary>
        /// EMPLOYEES
        /// </summary>
        private void FillEmployeeTable()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var personels = db.Employees.ToList();
                dataGridViewEmployee.DataSource = personels;
            }
        }
        private void FillGirdLayoutEmployee()
        {
            dataGridViewEmployee.AutoGenerateColumns = false;
            dataGridViewEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewEmployee.Columns.Add(GenerateColumn("FirstName", "Adı"));
            dataGridViewEmployee.Columns.Add(GenerateColumn("LastName", "Soyadı"));
            dataGridViewEmployee.Columns.Add(GenerateColumn("Title", "Ünvan"));
            dataGridViewEmployee.Columns.Add(GenerateColumn("BirthDate", "Doğum Tarihi"));
        }
        private void dataGridViewEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int emplopeeId = ((dataGridViewEmployee.DataSource as List<Employee>)[e.RowIndex]).EmployeeId;
            var form = new PersonelForm();
            form.Tag = emplopeeId;
            form.ShowDialog();
            FillEmployeeTable();
        }

        /// <summary>
        /// CATEGORIES
        /// </summary>
        private void FillCategoryTable()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var categories = db.Categories.ToList();
                dataGridViewCategory.DataSource = categories;
            }
        }
        private void FillGridLayoutCategory()
        {
            dataGridViewCategory.AutoGenerateColumns = false;
            dataGridViewCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewCategory.Columns.Add(GenerateColumn("CategoryName", "Kategori Adı"));
            dataGridViewCategory.Columns.Add(GenerateColumn("Description", "Kategori Açıklama"));
        }
        private void dataGridViewCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int categoryId = ((dataGridViewCategory.DataSource as List<Category>)[e.RowIndex]).CategoryId;
            var form = new CategoryForm();
            form.Tag = categoryId;
            form.ShowDialog();
            FillCategoryTable();
        }

        /// <summary>
        /// PRODUCTS
        /// </summary>
        private void FillProductTable()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var products = db.Products.ToList();
                dataGridViewProduct.DataSource = products;
            }
        }
        private void FillGridLayoutProducts()
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
        private void dataGridViewProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int productId = ((dataGridViewProduct.DataSource as List<Product>)[e.RowIndex].ProductId);
            var form = new ProductForm();
            form.Tag = productId;
            form.ShowDialog();
            FillProductTable();
        }

        /// <summary>
        /// SUPPLIERS
        /// </summary>
        private void FillGridLayoutSupplier()
        {
            dataGridViewSupplier.AutoGenerateColumns = false;
            dataGridViewSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewSupplier.Columns.Add(GenerateColumn("CompanyName", "Tedarikçi Adı"));
            dataGridViewSupplier.Columns.Add(GenerateColumn("ContactName", "İletişim Kurulan Kişi"));
            dataGridViewSupplier.Columns.Add(GenerateColumn("ContactTitle", "İletişim Kurulan Kişşi Ünvanı"));
        }
        private void FillSupplierTable()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var suppliers = db.Suppliers.ToList();
                dataGridViewSupplier.DataSource = suppliers;
            }
        }
        private void dataGridViewSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var supplierId = ((dataGridViewSupplier.DataSource as List<Supplier>)[e.RowIndex]).SupplierId;
            var form = new SupplierForm();
            form.Tag = supplierId;
            form.ShowDialog();
            FillSupplierTable();
        }
       /// <summary>
       /// GENERATE COLUMNS
       /// </summary>
       /// <param name="name"></param>
       /// <param name="caption"></param>
       /// <returns></returns>
        public DataGridViewColumn GenerateColumn(string name, string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName = name;
            column.HeaderText = caption;
            return column;
        }

    
    }
}
