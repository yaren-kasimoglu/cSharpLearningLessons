using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using ADONETODEV1.Model;

namespace ADONETODEV1
{
    public partial class ProductForm : Form
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public ProductForm()
        {
            InitializeComponent();
        }


        public int RecId { get; set; }

        private void ProductForm_Load(object sender, EventArgs e)
        {

            FillControl();

            if (RecId > 0)
            {

                FillForm();

            }
        }

        private void FillForm()
        {
            var product = GetProductById(this.RecId);
            if (product != null)
            {

                txtProductName.Text = product.ProductName;
                cmbSupplier.SelectedValue = product.SupplierID;
                cmbCategory.SelectedValue = product.CategoryID;
                txtQuantityPerUnit.Text = product.QuantityPerUnit;
                nuUnitPrice.Value = Convert.ToDecimal(product.UnitPrice);
                nuUnitsInStokVerisi.Value = Convert.ToDecimal(product.UnitsInStock);
                nuUnitsOnOrder.Value = Convert.ToDecimal(product.UnitsOnOrder);
                nuReorderLevel.Value = Convert.ToDecimal(product.ReorderLevel);
                chkDiscontinued.Checked = product.Discontinued;
            }
        }

        private void FillControl()
        {
            FillSupplier();
            FillCategories();
        }

        private void FillCategories()
        {
            cmbCategory.DataSource = null;
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.DataSource = GetCategories();

        }

        private void FillSupplier()
        {
            cmbSupplier.DataSource = null;
            cmbSupplier.ValueMember = "SupplierID";
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.DataSource = GetSuppliers();
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT SupplierID, CompanyName FROM dbo.Suppliers", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();
                            supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                            supplier.CompanyName = Convert.ToString(reader["CompanyName"]);
                            suppliers.Add(supplier);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return suppliers;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT CategoryID, CategoryName FROM dbo.Categories", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Category category = new Category();
                            category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                            category.CategoryName = Convert.ToString(reader["CategoryName"]);
                            categories.Add(category);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return categories;
        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("select top 1 * from dbo.Products where ProductID=@ProductID", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        command.Parameters.AddWithValue("ProductID", productId);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            product = new Product();
                            product.ProductID = Convert.ToInt32(reader["ProductID"]);
                            product.ProductName = Convert.ToString(reader["ProductName"]);
                            product.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                            product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                            product.QuantityPerUnit = Convert.ToString(reader["QuantityPerUnit"]);
                            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                            product.UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]);
                            product.UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]);
                            product.ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]);
                            product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);
                        }
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return product;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }
        public void FormClear()     
        {
            this.RecId = 0;
            txtProductName.Text = "";
            txtQuantityPerUnit.Text = "";
            cmbCategory.SelectedIndex = -1;
            cmbSupplier.SelectedIndex = -1;
            nuReorderLevel.Value = 0;
            nuUnitPrice.Value = 0;
            nuUnitsInStokVerisi.Value = 0;
            nuUnitsOnOrder.Value = 0;
            chkDiscontinued.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        public void FormSave()
        {
            var product = new Product();
            product.ProductID = this.RecId;
            product.ProductName = this.txtProductName.Text;
            product.QuantityPerUnit = this.txtQuantityPerUnit.Text;
            product.Discontinued = this.chkDiscontinued.Checked;
            product.SupplierID = Convert.ToInt32(cmbSupplier.SelectedValue);
            product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            product.UnitPrice = nuUnitPrice.Value;
            product.UnitsInStock = Convert.ToInt16(nuUnitsInStokVerisi.Value);
            product.UnitsOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
            product.ReorderLevel = Convert.ToInt16(nuReorderLevel.Value);

            if (this.RecId == 0)
            {
  
                if (FormInsert(product))
                {
                    MessageBox.Show("İşlem başarılı bir şekilde gerçekleşti");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi");

                }
            }
            else
            {

                if (FormUpdate(product))
                {
                    MessageBox.Show("İşlem başarılı bir şekilde gerçekleşti");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi");

                }

            }
        }

        public bool FormInsert(Product item)
        {
            string sql = @"INSERT INTO dbo.Products
(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
VALUES
(@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("ProductName", item.ProductName);
                        command.Parameters.AddWithValue("SupplierID", item.SupplierID);
                        command.Parameters.AddWithValue("CategoryID", item.CategoryID);
                        command.Parameters.AddWithValue("QuantityPerUnit", item.QuantityPerUnit);
                        command.Parameters.AddWithValue("UnitPrice", item.UnitPrice);
                        command.Parameters.AddWithValue("UnitsInStock", item.UnitsInStock);
                        command.Parameters.AddWithValue("UnitsOnOrder", item.UnitsOnOrder);
                        command.Parameters.AddWithValue("ReorderLevel", item.ReorderLevel);
                        command.Parameters.AddWithValue("Discontinued", item.Discontinued);

                        if (con.State == ConnectionState.Closed) con.Open();

                        //ExecuteNonQuery =>  insert, update, delete işlemlerinde kulanılır
                        int count = command.ExecuteNonQuery();   //etkilenen satır sayısı
                        if (count > 0)   //etkilenen satır sayısı 0 dan büyükse işlem başarılı bir şekilde DB ye yansımıştır.
                            result = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
        }

        public bool FormUpdate(Product item)
        {
            string sql = @"UPDATE dbo.Products SET 
                            ProductName = @ProductName,
                            SupplierID = @SupplierID,
                            CategoryID = @CategoryID,
                            QuantityPerUnit = @QuantityPerUnit,
                            UnitPrice = @UnitPrice,
                            UnitsInStock = @UnitsInStock,
                            UnitsOnOrder = @UnitsOnOrder,
                            ReorderLevel = @ReorderLevel,
                            Discontinued = @Discontinued
                            WHERE ProductID = @ProductID";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("ProductName", item.ProductName);
                        command.Parameters.AddWithValue("SupplierID", item.SupplierID);
                        command.Parameters.AddWithValue("CategoryID", item.CategoryID);
                        command.Parameters.AddWithValue("QuantityPerUnit", item.QuantityPerUnit);
                        command.Parameters.AddWithValue("UnitPrice", item.UnitPrice);
                        command.Parameters.AddWithValue("UnitsInStock", item.UnitsInStock);
                        command.Parameters.AddWithValue("UnitsOnOrder", item.UnitsOnOrder);
                        command.Parameters.AddWithValue("ReorderLevel", item.ReorderLevel);
                        command.Parameters.AddWithValue("Discontinued", item.Discontinued);
                        command.Parameters.AddWithValue("ProductID", item.ProductID);

                        if (con.State == ConnectionState.Closed) con.Open();

                        //ExecuteNonQuery =>  insert, update, delete işlemlerinde kulanılır
                        int count = command.ExecuteNonQuery();   //etkilenen satır sayısı
                        if (count > 0)   //etkilenen satır sayısı 0 dan büyükse işlem başarılı bir şekilde DB ye yansımıştır.
                            result = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
        }

        public bool FormDelete()
        {
            bool result = false;
            var dialog = MessageBox.Show("Ürünü silmek istediğinizden emin misiniz?", "Ürün Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("DELETE dbo.Products WHERE ProductID = @ProductID", con))
                        {
                            command.Parameters.AddWithValue("ProductID", this.RecId);
                            if (con.State == ConnectionState.Closed) con.Open();

                            int count = command.ExecuteNonQuery();
                            if (count > 0) result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return result;

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(this.RecId > 0)
            {
                if (FormDelete())
                {
                    MessageBox.Show("Silme işlemi başarılı");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Silme işlemi gerçekleşemedi");

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

