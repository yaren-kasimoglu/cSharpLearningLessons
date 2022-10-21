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
    public partial class ShipperForm : Form
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public ShipperForm()
        {
            InitializeComponent();
        }

        public int RecId { get; set; }
        private void ShipperForm_Load(object sender, EventArgs e)
        {
            if (RecId > 0)
            {
                FillForm();
            }
        }

        private void FillForm()
        {
            var shipper = GetShipperById(this.RecId);
            if (shipper != null)
            {
                txtSipperName.Text = shipper.CompanyName;
                txtPhone.Text = shipper.Phone;
            }
        }

        private Shippers GetShipperById(int shipperId)
        {
            Shippers shipper = null;

            string sql = "select top 1 * from dbo.Shippers where ShipperID=@ShipperID";

            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        command.Parameters.AddWithValue("ShipperID", shipperId);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            shipper = new Shippers();

                            shipper.ShipperID = Convert.ToInt32(reader["ShipperID"]);
                            shipper.CompanyName = Convert.ToString(reader["CompanyName"]);
                            shipper.Phone = Convert.ToString(reader["Phone"]);
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            return shipper;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            txtSipperName.Text = "";
            txtPhone.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        public bool FormInsert(Shippers item)
        {
            string sql = @"INSERT INTO Shippers(CompanyName,Phone)
VALUES
(@CompanyName, @Phone)";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CompanyName", item.CompanyName);
                        command.Parameters.AddWithValue("Phone", item.Phone);

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

        public bool FormUpdate(Shippers item)
        {
            string sql = @"UPDATE dbo.Shippers SET 
                            CompanyName = @CompanyName,
                            Phone = @Phone
                            where ShipperID=@ShipperID";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CompanyName", item.CompanyName);
                        command.Parameters.AddWithValue("Phone", item.Phone);
                        command.Parameters.AddWithValue("ShipperID",item.ShipperID);

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


        private void FormSave()
        {
            var shipper = new Shippers();
            shipper.ShipperID = this.RecId;
            shipper.CompanyName = this.txtSipperName.Text;
            shipper.Phone = this.txtPhone.Text;


            if (this.RecId == 0)
            {

                if (FormInsert(shipper))
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

                if (FormUpdate(shipper))
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.RecId > 0)
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

        private bool FormDelete()
        {
            bool result = false;
            var dialog = MessageBox.Show("Nakliyeyi silmek istediğinizden emin misiniz?", "Kategori Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("DELETE dbo.Shippers WHERE ShipperID = @ShipperID", con))
                        {
                            command.Parameters.AddWithValue("ShipperID", this.RecId);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
