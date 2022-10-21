using ADONETODEV1.Model;
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

namespace ADONETODEV1
{
    public partial class CustomerForm : Form
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public CustomerForm()
        {
            InitializeComponent();
        }

        public string RecId { get; set; }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FillControl();

            if (RecId != null)
            {

                FillForm();

            }
        }

        private void FillForm()
        {
            var customer = GetCustomerById(this.RecId);
            if (customer != null)
            {
                txtCustomerName.Text = customer.CompanyName;
                txtContactName.Text = customer.ContactName;
                txtContactTitle.Text = customer.ContactTitle;
                txtAddress.Text = customer.Address;
                txtCity.Text = customer.City;
                cmbRegion.Text = customer.Region;
                txtPostalCode.Text = customer.PostalCode;
                txtCountry.Text = customer.Country;
                txtPhone.Text = customer.Phone;
                txtFax.Text = customer.Fax;
               
            }  
        }

        private void FillControl()
        {
            FillRegion();
        }

        private void FillRegion()
        {
            cmbRegion.DataSource = null;
            cmbRegion.ValueMember = "RegionID";
            cmbRegion.DisplayMember = "RegionDescription";
            cmbRegion.DataSource = GetRegions();
        }

        public List<Regions> GetRegions()
        {
            List<Regions> regions = new List<Regions>();
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT *FROM Region", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {

                            Regions region = new Regions();

                            region.RegionID = Convert.ToInt32(reader["RegionID"]);
                            region.RegionDescription = Convert.ToString(reader["RegionDescription"]);
                            regions.Add(region);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return regions;
        }


        public Customer GetCustomerById(string customerID)
        {
            Customer customer = null;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("select top 1 * from dbo.Customers where CustomerID=@CustomerID", con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        command.Parameters.AddWithValue("CustomerID", customerID);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customer = new Customer();

                            customer.CustomerID = Convert.ToString(reader["CustomerID"]);
                            customer.CompanyName = Convert.ToString(reader["CompanyName"]);
                            customer.ContactName = Convert.ToString(reader["ContactName"]);
                            customer.ContactTitle = Convert.ToString(reader["ContactTitle"]);
                            customer.Address = Convert.ToString(reader["Address"]);
                            customer.City = Convert.ToString(reader["City"]);
                            customer.Region = Convert.ToString(reader["Region"]);
                            customer.PostalCode = Convert.ToString(reader["PostalCode"]);
                            customer.Country = Convert.ToString(reader["Country"]);
                            customer.Phone = Convert.ToString(reader["Phone"]);
                            customer.Fax = Convert.ToString(reader["Fax"]);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return customer;
        }

        public void FormClear()
        {
            this.RecId = "";

            txtCustomerName.Text = "";
            txtContactName.Text = "";
            txtContactTitle.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            cmbRegion.SelectedItem = -1;
            txtPostalCode.Text ="";
        }


        public void FormSave()
        {
            var customer = new Customer();
            customer.CustomerID = this.RecId;

            customer.CompanyName = this.txtCustomerName.Text;
            customer.ContactName = this.txtContactName.Text;
            customer.ContactTitle = this.txtContactTitle.Text;
            customer.City = this.txtCity.Text;
            customer.Region = Convert.ToString(cmbRegion.SelectedValue);
            customer.PostalCode = this.txtPostalCode.Text;
            customer.Country = this.txtCountry.Text;
            customer.Phone = this.txtPhone.Text;
            customer.Address = this.txtAddress.Text;
            customer.Fax = this.txtFax.Text;

            if (this.RecId ==null)
            {

                if (FormInsert(customer))
                {
                    MessageBox.Show("İşlem başarılı bir şekilde gerçekleşti");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi");

                }
            }
            else
            {

                if (FormUpdate(customer))
                {
                    MessageBox.Show("İşlem başarılı bir şekilde gerçekleşti");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir hata meydana geldi");

                }

            }
        }

        public bool FormInsert(Customer item)
        {
            string sql = @"INSERT INTO dbo.Customers
(CompanyName, ContactName, ContactTitle, Address, City, Region,PostalCode, Country,Phone,Fax)
VALUES
(@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone,@Fax)";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CompanyName", item.CompanyName);
                        command.Parameters.AddWithValue("ContactName", item.ContactName);
                        command.Parameters.AddWithValue("ContactTitle", item.ContactTitle);
                        command.Parameters.AddWithValue("Address", item.Address);
                        command.Parameters.AddWithValue("City", item.City);
                        command.Parameters.AddWithValue("Region", item.Region);
                        command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                        command.Parameters.AddWithValue("Country", item.Country);
                        command.Parameters.AddWithValue("Phone", item.Phone);
                        command.Parameters.AddWithValue("Fax", item.Fax);

                        if (con.State == ConnectionState.Closed) con.Open();

                        int count = command.ExecuteNonQuery();   
                        if (count > 0)   
                            result = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
        }

        public bool FormUpdate(Customer item)
        {
            string sql = @"UPDATE dbo.Customers SET 
                            CompanyName=@CompanyName,
                            ContactName=@ContactName,
                            ContactTitle=@ContactTitle, 
                            Address=@Address, 
                            City=@City, 
                            Region=@Region,
                            PostalCode=@PostalCode, 
                            Country=@Country,
                            Phone=@Phone,
                            Fax=@Fax
                            where CustomerID=@CustomerID";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CompanyName", item.CompanyName);
                        command.Parameters.AddWithValue("ContactName", item.ContactName);
                        command.Parameters.AddWithValue("ContactTitle", item.ContactTitle);
                        command.Parameters.AddWithValue("Address", item.Address);
                        command.Parameters.AddWithValue("City", item.City);
                        command.Parameters.AddWithValue("Region", item.Region);
                        command.Parameters.AddWithValue("PostalCode", item.PostalCode);
                        command.Parameters.AddWithValue("Country", item.Country);
                        command.Parameters.AddWithValue("Phone", item.Phone);
                        command.Parameters.AddWithValue("Fax", item.Fax);

                        if (con.State == ConnectionState.Closed) con.Open();

                       
                        int count = command.ExecuteNonQuery();   
                        if (count > 0)   
                            result = true;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return result;
            }
        }

        public bool FormDelete()
        {
            bool result = false;
            var dialog = MessageBox.Show("Müşteriyi silmek istediğinizden emin misiniz?", "Müşteri Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("DELETE dbo.Customers WHERE CustomerID = @CustomerID", con))
                        {
                            command.Parameters.AddWithValue("CustomerID", this.RecId);
                            if (con.State == ConnectionState.Closed) con.Open();

                            int count = command.ExecuteNonQuery();
                            if (count > 0) result = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            return result;

        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.RecId != null)
            {
                if (FormDelete())
                {
                    MessageBox.Show("Silme işlemi başarılı");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Silme işlemi gerçekleşemedi");

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }
    }
}
