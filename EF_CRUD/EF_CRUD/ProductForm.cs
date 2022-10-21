using EF_CRUD.Core.Model;
using EF_CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CRUD
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
            FillData();
            FillControl();
        }

        private void FillControl()
        {
            FillSupplier();
            FillCategories();
        }

        private void FillCategories()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var categoryKeyValueList = db.Categories.Select(c => new KeyValue(c.CategoryId, c.CategoryName)).ToList();
                cmbCategoryId.DisplayMember = "Value";
                cmbCategoryId.ValueMember = "Id";
                cmbCategoryId.DataSource = categoryKeyValueList;

            }
        }

        private void FillSupplier()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var supplierKeyValueList = db.Suppliers.Select(s => new KeyValue(s.SupplierId, s.CompanyName)).ToList();
                cmbSupplierId.DisplayMember = "Value";
                cmbSupplierId.ValueMember = "Id";
                cmbSupplierId.DataSource = supplierKeyValueList;
            }
        }

        private void FillData()
        {
            int productId = Convert.ToInt32(this.Tag);

            if (productId > 0)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
                    if (product != null)
                    {
                        txtProductName.Text = product.ProductName;
                        txtQuantityPerUnit.Text = product.QuantityPerUnit;
                        nuReOrderLevel.Value = Convert.ToDecimal(product.ReorderLevel);
                        nuUnitPrice.Value = Convert.ToDecimal(product.UnitPrice);
                        nuUnitsInStock.Value = Convert.ToDecimal(product.UnitsInStock);
                        nuUnitsOnOrder.Value = Convert.ToDecimal(product.UnitsOnOrder);
                        cmbSupplierId.SelectedValue = product.SupplierId;
                        cmbCategoryId.SelectedValue = product.CategoryId;
                        chkDiscontinues.Checked = product.Discontinued;

                    }
                }
            }
        }


        private void FormDelete()
        {
            if (this.Tag != null)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?", "PErsonel Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    using (NorthwindContext db = new NorthwindContext())
                    {
                        try
                        {
                            int productId = Convert.ToInt32(this.Tag);
                            var products = db.Products.FirstOrDefault(t => t.ProductId == productId);
                            if (products != null)
                            {
                                db.Products.Remove(products);
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

        private void FormClear()
        {
            this.Tag = 0;

            this.txtProductName.Text = "";
            this.txtQuantityPerUnit.Text = "";
            this.nuUnitsOnOrder.Value = 0;
            this.nuUnitsInStock.Value = 0;
            this.nuUnitPrice.Value = 0;
            this.nuReOrderLevel.Value = 0;
            this.cmbCategoryId.SelectedIndex = 0;
            this.cmbSupplierId.SelectedIndex = 0;
            this.chkDiscontinues.Checked = false;

        }


        private void FormSave()
        {
            try
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    Product product; ;
                    int ProductId = Convert.ToInt32(this.Tag);

                    if (ProductId == 0)
                    {//insert
                        product = new Product();
                        db.Products.Add(product);
                    }

                    else
                    {
                        product = db.Products.FirstOrDefault(t0 => t0.ProductId == ProductId);

                        if (product != null)
                        {

                            product.ProductName = txtProductName.Text;
                            product.QuantityPerUnit = txtQuantityPerUnit.Text;
                            product.UnitPrice = nuUnitPrice.Value;
                            product.UnitsInStock = Convert.ToInt16(nuUnitsInStock.Value);
                            product.UnitsOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
                            product.ReorderLevel = Convert.ToInt16(nuReOrderLevel.Value);
                            product.Discontinued = chkDiscontinues.Checked;

                            if (cmbSupplierId.SelectedIndex > -1)
                            {
                                product.SupplierId = (cmbSupplierId.SelectedItem as KeyValue).Id;
                            }

                            if (cmbCategoryId.SelectedIndex > -1)
                            {
                                product.CategoryId = (cmbCategoryId.SelectedItem as KeyValue).Id;
                            }


                            db.SaveChanges();

                            this.Tag = product.ProductId;
                            MessageBox.Show("işlem başarılı");
                            this.Close();

                        }
                    }
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }
    }
}
