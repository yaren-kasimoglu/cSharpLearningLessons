using AdoNetConnected_.Model;
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

namespace AdoNetConnected_
{
    public partial class Form1 : Form
    {
        public Form1()
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
        }

        private void FillProducts()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetProduct();
        }

        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("Select * from Products", con))
                    {
                        if (con.State==ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlDataReader reader=command.ExecuteReader();
                        while (reader.Read())
                        {
                            var product = new Product();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           var product= (dataGridView1.DataSource as List<Product>)[e.RowIndex];
            MessageBox.Show(product.ProductID.ToString());
            if (product!=null)
            {
                ProductsForm pf = new ProductsForm();
                pf.RecId=product.ProductID;
                pf.ShowDialog();
            }
        }
    }
}