using EF_CodeFirst_CRUD.DAL.Context;
using EF_CodeFirst_CRUD.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CodeFirst_CRUD
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            int productId = Convert.ToInt32(this.Tag);
            if (productId>0)
            {
                using (CrmContext db=new CrmContext())
                {

                }
            }
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
            int productId=Convert.ToInt32(this.Tag);

            try
            {
                using (CrmContext db = new CrmContext())
                {
                    Product? product = null;
                    if (productId == 0)
                    {
                        product = new Product();
                        db.Product.Add(product);

                    }
                    else
                    {
                        product = db.Product.FirstOrDefault(p => p.ProductId == productId);
                    }

                    if (product != null)
                    {
                        product.ProductName = txtProductName.Text;
                        product.Description = txtDescription.Text;
                        product.ProductCode = txtProductCode.Text;
                        product.UnitPrice = nuUnitPrice.Value;
                    }
                    db.SaveChanges();
                    this.Tag = product.ProductId;
                    MessageBox.Show("KAyıt Başarılı");
                    this.Close();
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
            if (productId>0)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?", "PErsonel Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    using (CrmContext db=new CrmContext())
                    {
                        try
                        {                       
                           var product = db.Product.FirstOrDefault(t => t.ProductId == productId);
                            if (product!=null)
                            {
                                db.Product.Remove(product);
                                db.SaveChanges();
                                MessageBox.Show("İşlem Başarılı");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                }
        }
    }
}
