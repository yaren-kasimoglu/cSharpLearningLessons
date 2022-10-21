using EFCore_CodeFirst_Application.DAL.Context;
using EFCore_CodeFirst_Application.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCore_CodeFirst_Application
{
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ShowProductForm(0);
            FillProduct();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                var productObject = (dataGridView1.DataSource as List<Product>)[e.RowIndex];

                if (productObject!=null)
                {
                    ShowProductForm(productObject.ProductId);
                    FillProduct();
                }
            }

        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            FillControl();
        }

        private void FillControl()
        {
            FillProduct();
        }

        private void FillProduct()
        {
            using (CrmContext db=new CrmContext())
            {
                var result = db.Product.ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;

            }
        }

        private void ShowProductForm(int productId)
        {
            var form=new ProductForm();
            form.Tag = productId;
            form.ShowDialog();

        }
    }
}
