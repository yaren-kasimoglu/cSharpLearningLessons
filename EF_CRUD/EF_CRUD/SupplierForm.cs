using EF_CRUD.Core.Model;
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
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillData();

        }

        private void FillData()
        {
            int supplierId = Convert.ToInt32(this.Tag);

            if (supplierId > 0)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                    if (supplierId != null)
                    {
                        txtCompanName.Text = supplier.CompanyName;
                        txtContactName.Text = supplier.ContactName;
                        txtContactTitle.Text = supplier.ContactTitle;
                        txtAddress.Text = supplier.Address;
                        txtCity.Text = supplier.City;
                        txtPostalCode.Text = supplier.PostalCode;
                        txtCountry.Text = supplier.Country;
                        txtPhone.Text = supplier.Phone;
                        txtFax.Text = supplier.Fax;
                        txtRegion.Text = supplier.Region;
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            this.Tag = 0;
            this.txtCompanName.Text = "";
            this.txtContactName.Text = "";
            this.txtContactTitle.Text = "";
            this.txtAddress.Text = "";
            this.txtCity.Text = "";
            this.txtPostalCode.Text = "";
            this.txtCountry.Text = "";
            this.txtPhone.Text = "";
            this.txtFax.Text = "";
            this.txtRegion.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    Supplier supplier;
                    var supplierId = Convert.ToInt32(this.Tag);

                    if (supplierId == 0)
                    {
                        supplier = new Supplier();
                        db.Suppliers.Add(supplier);
                    }
                    else
                    {
                        supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                    }
                    if (supplier != null)
                    {
                        supplier.CompanyName = txtCompanName.Text;
                        supplier.ContactName = txtContactName.Text;
                        supplier.ContactTitle = txtContactTitle.Text;
                        supplier.Address = txtAddress.Text;
                        supplier.City = txtCity.Text;
                        supplier.PostalCode = txtPostalCode.Text;
                        supplier.Country = txtCountry.Text;
                        supplier.Phone = txtPhone.Text;
                        supplier.Fax = txtFax.Text;
                        supplier.Region = txtRegion.Text;
                        db.SaveChanges();
                        this.Tag=supplier.SupplierId;
                        MessageBox.Show("işlem başarılı");
                        this.Close();

                    }
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
            if (this.Tag != null)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?", "PErsonel Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    using (NorthwindContext db =new NorthwindContext())
                    {
                        try
                        {
                            int supplierId = Convert.ToInt32(this.Tag);
                            var supplier = db.Suppliers.FirstOrDefault(s => s.SupplierId == supplierId);
                            if (supplier!=null)
                            {
                                db.Suppliers.Remove(supplier);
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
