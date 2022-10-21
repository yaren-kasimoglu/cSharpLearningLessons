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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            txtDescription.Text = "";
            nuUnitPrice.Value = 0;
            this.Tag = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            int productId = Convert.ToInt32(this.Tag);
            Product productObject = null;
            try
            {
                using (CrmContext db = new CrmContext())
                {

                    if (productId == 0)
                    {
                        productObject = new Product();
                        db.Add(productObject);
                    }
                    else
                    {
                        productObject = db.Product.FirstOrDefault(p => p.ProductId == productId);

                    }
                    if (productObject != null)
                    {
                        productObject.ProductName = txtProductName.Text;
                        productObject.ProductCode = txtProductCode.Text;
                        productObject.Description = txtDescription.Text;
                        productObject.UnitPrice = nuUnitPrice.Value;
                    }
                    db.SaveChanges();
                    this.Tag = productObject.ProductId;
                    MessageBox.Show("Kayıt işlemi başarılı.");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void FormDelete()
        {
            int productId = Convert.ToInt32(this.Tag);

            if (productId > 0)
            {
                var dialog = MessageBox.Show("Seçilen Ürünü silmek istiyor musunuz?", "CRM", MessageBoxButtons.OK, MessageBoxIcon.Question);

                if (dialog == DialogResult.OK)
                {
                    using (CrmContext db = new CrmContext())
                    {
                        var productObject = db.Product.FirstOrDefault(p => p.ProductId == productId);

                        db.Product.Remove(productObject);
                        db.SaveChanges();
                        MessageBox.Show("İşlem Başarılı");
                        this.Close();
                    }
                }
            }
        }
    }
}
