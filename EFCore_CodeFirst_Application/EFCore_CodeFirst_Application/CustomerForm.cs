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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillForm();
        }

        private void FillForm()
        {
            int customerId = Convert.ToInt32(this.Tag);
            if (customerId > 0)
            {
                using (CrmContext db = new CrmContext())
                {
                    var result = db.Customer.FirstOrDefault(x => x.CustomerId == customerId);

                    if (result != null)
                    {
                        txtCustomerName.Text = result.CustomerName;
                        txtAddress.Text = result.Address;
                        txtEmial.Text = result.Email;
                        txtPhone.Text = result.Phone;
                        cmbCountry.SelectedValue = result.CountryId;
                        cmbCity.SelectedValue = result.CityId;
                    }
                }
            }
        }

        private void FillControl()
        {
            FillCountry();
            FillCity();

        }

        private void FillCountry()
        {
            using (CrmContext db = new CrmContext())
            {
                var result = db.Country.Select(x => new { Value = x.CountryId, Text = x.CountryName }).ToList();
                cmbCountry.DisplayMember = "Text";
                cmbCountry.ValueMember = "Value";
                cmbCountry.DataSource = result;

            }
        }

        private void FillCity()
        {
            if (cmbCountry.SelectedIndex > -1)
            {
                int selectedCountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                using (CrmContext db = new CrmContext())
                {
                    var result = db.City.Where(x => x.CountryId == selectedCountryId).Select(x => new { Value = x.CityId, Text = x.CityName }).ToList();
                    cmbCity.DisplayMember = "Text";
                    cmbCity.ValueMember = "Value";
                    cmbCity.DataSource = result;

                }
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillCity();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtEmial.Text = "";
            txtPhone.Text = "";
            cmbCity.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
            this.Tag = 0;
        }

        private void FormSave()
        {
            int customerId = Convert.ToInt32(this.Tag);

            try
            {
                using (CrmContext db = new CrmContext())
                {
                    Customer? customerObject = null;

                    if (customerId == 0)
                    {
                        customerObject = new Customer();
                        db.Customer.Add(customerObject);
                    }
                    else
                    {
                        customerObject = db.Customer.FirstOrDefault(x => x.CustomerId == customerId);
                    }

                    if (customerObject != null)
                    {
                        customerObject.CustomerName = txtCustomerName.Text;
                        customerObject.Address = txtAddress.Text;
                        customerObject.Phone = txtPhone.Text;
                        customerObject.Email = txtEmial.Text;
                        customerObject.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                        customerObject.CityId = Convert.ToInt32(cmbCity.SelectedValue);

                        db.SaveChanges();
                        this.Tag = customerObject.CustomerId;
                        MessageBox.Show("Kayıt Başarılı");
                        this.Close();
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            FormSave();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void FormDelete()
        {
            int customerId = Convert.ToInt32(this.Tag);
            if (customerId > 0)
            {
                var dialog = MessageBox.Show("Mevcut kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    try
                    {
                        using (CrmContext db = new CrmContext())
                        {
                            var customer = db.Customer.FirstOrDefault(x => x.CustomerId == customerId);
                            if (customer != null)
                            {
                                db.Customer.Remove(customer);
                                db.SaveChanges();
                                MessageBox.Show("İşlem Başaırlı");
                                this.Close();

                            }

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
