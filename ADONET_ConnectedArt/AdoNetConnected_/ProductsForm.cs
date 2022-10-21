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
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public int RecId { get; set; }
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            FillForm();
          
        }

        private void FillForm()
        {
            FillSupplier();
        }

        private void FillSupplier()
        {
            
        }

        public List<Supplier> GetSupplier()
        {
            using (SqlConnection con = new SqlConnection(_ConnectionString)
            {
                
            }


        }
    }
}
