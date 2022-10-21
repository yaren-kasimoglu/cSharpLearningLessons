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
                using (CrmContext DB = new CrmContext())
                {
                    var result = DB.Customer.FirstOrDefault(t0 => t0.CustomerId == customerId);
                    if (result != null)
                    {
                        txtCustomerName.Text = result.CustomerName;
                        txtEmial.Text = result.Email;
                        txtPhone.Text = result.Phone;
                        txtAddress.Text = result.Address;
                        cmbCountry.SelectedValue = result.CountryId;
                        cmbCity.SelectedValue = result.CityId;
                    }
                }
            }
        }
        private void FillControl()
        {
            FillCountry();

        }

        private void FillCountry()
        {
            using (CrmContext db=new CrmContext())
            {
                var result=db.Country.Select(c=> new {Value=c.CountryId, Text=c.CountryName}).ToList();
                cmbCountry.DisplayMember = "Text";
                cmbCountry.ValueMember = "Value";
                cmbCountry.DataSource = result;
            }
        }

        private void FillCity()
        {
            using (CrmContext db = new CrmContext())
            {
                if (cmbCountry.SelectedIndex>-1)
                {           
                int SelecteedcountryId =Convert.ToInt32( cmbCountry.SelectedValue);
                var result = db.City.Where(t=>t.CountryId== SelecteedcountryId).Select(t=> new { Value=t.CityId, Text=t.CityName}).ToList();
                    cmbCity.DisplayMember = "Text";
                    cmbCity.ValueMember = "Value";
                    cmbCity.DataSource = result;
                }
                else
                {
                    cmbCity.DataSource = null;
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
            txtEmial.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            cmbCity.SelectedIndex = -1;
            cmbCountry.SelectedIndex = -1;
            this.Tag = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
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
                        customerObject = db.Customer.FirstOrDefault(t => t.CustomerId == customerId);
                    }

                    if (customerObject != null)
                    {
                        customerObject.CustomerName = txtCustomerName.Text;
                        customerObject.Phone = txtPhone.Text;
                        customerObject.Email = txtEmial.Text;
                        customerObject.Address = txtAddress.Text;

                        customerObject.CountryId = Convert.ToInt32(cmbCountry.SelectedValue);
                        customerObject.CityId = Convert.ToInt32(cmbCity.SelectedValue);

                        db.SaveChanges();
                        this.Tag = customerObject.CustomerId;
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
            int customerId = Convert.ToInt32(this.Tag);
            if (customerId > 0)
            {
                var dialog = MessageBox.Show("Mevcut kaydı silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    using (CrmContext DB = new CrmContext())
                    {
                        var result = DB.Customer.FirstOrDefault();
                        if (result != null)
                        {
                            DB.Customer.Remove(result);
                            DB.SaveChanges();
                            MessageBox.Show("İşlem başarılı", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
