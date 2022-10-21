using AdoNetOrn.Model;
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

namespace AdoNetOrn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //app config dosyasının içindeki conn stringlerden name i db olanı oku
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        //string _connectionString = @"Server=DESKTOP-MAKL7QI; Database=Northwind; Trusted_Connection=true;";
        private void button1_Click(object sender, EventArgs e)
        {


            dataGridView1.DataSource = GetProducts();
        }

        public List<Products> GetProducts()
        {

            List<Products> productsList = new List<Products>();
            using (SqlConnection conn = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("Select * from Products", conn)) // sql cümlesini view kullanarak da yazabiliriz. örnk yukarda string sql diyip view oraya veririz ardından burdaki sorgu yerine sql yazarız
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var product = new Products();
                            product.ProductID = Convert.ToInt32(reader["ProductID"]);
                            product.ProductName = Convert.ToString(reader["ProductName"]);
                            product.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                            product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                            product.QuantityPerUnit = Convert.ToString(reader["QuantityPerUnit"]);
                            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                            product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                            product.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"]);

                            productsList.Add(product);
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return productsList;

        }
    }
}
