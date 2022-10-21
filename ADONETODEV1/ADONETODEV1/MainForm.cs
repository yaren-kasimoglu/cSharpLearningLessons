using ADONETODEV1;
using ADONETODEV1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONETODEV1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillProducts();
            FillCategories();
            FillCustomers();
            FillShipper();
        }

        private void FillProducts()
        {
            grdProducts.DataSource = null;
            grdProducts.DataSource = GetProduct();
        }
        private void FillCategories()
        {
            grdCategories.DataSource = null;
            grdCategories.DataSource = GetCategory();
        }
        private void FillCustomers()
        {
            gridCustomer.DataSource = null;
            gridCustomer.DataSource = GetCustomer();
        }
        private void FillShipper()
        {
            grdShipper.DataSource = null;
            grdShipper.DataSource = GetShipper();
        }


        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))    
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("select * from dbo.Products", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
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
                            products.Add(product);

                        }
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return products;
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var product = (grdProducts.DataSource as List<Product>)[e.RowIndex];

            if (product != null)
            {
                ProductForm form = new ProductForm();
                form.RecId = product.ProductID;
                form.ShowDialog();
                FillProducts();
            }
        }

       
        /// ///////////////////////////////////////////////////////////////////
      
        //KATEGORİ

        public List<Category> GetCategory()
        {
            string sqlCategories = "select CategoryID,CategoryName,Description from Categories";
            List<Category> categories = new List<Category>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sqlCategories, con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Category category = new Category();

                            category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                            category.CategoryName = Convert.ToString(reader["CategoryName"]);
                            category.Description = Convert.ToString(reader["Description"]);
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
        private void grdCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var category = (grdCategories.DataSource as List<Category>)[e.RowIndex];
            if (category!=null)
            {
                CategoryForm form = new CategoryForm();
                form.RecId=category.CategoryID;
                form.ShowDialog();
                FillCategories();
            }
        }


    
        /// //////////////////
        //CUSTOMER-MÜŞTERİ

        public List<Customer> GetCustomer()
        {
            string sql = "Select * from Customers";
            List<Customer> customers = new List<Customer>();
            using (SqlConnection con=new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command=new SqlCommand(sql,con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Customer customer=new Customer();
                            customer.CustomerID = Convert.ToString(reader["CustomerID"]);
                            customer.CompanyName = Convert.ToString(reader["CompanyName"]);
                            customer.ContactName = Convert.ToString(reader["ContactName"]);
                            customer.ContactTitle = Convert.ToString(reader["ContactTitle"]);
                            customer.Address = Convert.ToString(reader["Address"]);
                            customer.City = Convert.ToString(reader["City"]);
                            customer.Region = Convert.ToString(reader["Region"]);
                            customer.PostalCode = Convert.ToString(reader["PostalCode"]);
                            customer.Country = Convert.ToString(reader["Country"]);
                            customer.Phone = Convert.ToString(reader["Phone"]);
                            customer.Fax = Convert.ToString(reader["Fax"]);
                          
                           
                            customers.Add(customer);

                        }
                       

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            return customers;

        }

        private void gridCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var customer = (gridCustomer.DataSource as List<Customer>)[e.RowIndex];
            if (customer != null)
            {
                CustomerForm form = new CustomerForm();
                form.RecId = customer.CustomerID;
                form.ShowDialog();
                FillCustomers();
            }
        }
        
        
        /// //////////////////
        //SHIPPER
        public List<Shippers> GetShipper()
        {
            string sql = "Select * from Shippers";
            List<Shippers> shippers = new List<Shippers>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Shippers shipper = new Shippers();
                            shipper.ShipperID = Convert.ToInt32(reader["ShipperID"]);
                            shipper.CompanyName = Convert.ToString(reader["CompanyName"]);
                            shipper.Phone = Convert.ToString(reader["Phone"]);

                            shippers.Add(shipper);

                        }


                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            return shippers;
        }

        private void grdShipper_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var shipper = (grdShipper.DataSource as List<Shippers>)[e.RowIndex];
            if (shipper!=null)
            {
                ShipperForm form = new ShipperForm();
                form.RecId=shipper.ShipperID;
                form.ShowDialog();
                FillShipper();
            }
        }
    }
}
