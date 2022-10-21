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
    public partial class CategoryForm : Form
    {
        string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public CategoryForm()
        {
            InitializeComponent();
        }

        public int RecId { get; set; }
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            
            if (RecId>0)
            {
                FillForm();
            }
        }

        private void FillForm()
        {
            var category = GetCategoryById(this.RecId);
            if (category != null)
            {
                txtCategoryName.Text = category.CategoryName;
                txtCategoryDescription.Text = category.Description;
            }
        }

        private Category GetCategoryById(int categoryId)
        {
            Category category = null;

            string sqlCategories = "select top 1 * from dbo.Categories where CategoryID=@CategoryID";
          
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sqlCategories, con))
                    {
                        if (con.State == ConnectionState.Closed) con.Open();
                        command.Parameters.AddWithValue("CategoryID", categoryId);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                           category = new Category();

                            category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                            category.CategoryName = Convert.ToString(reader["CategoryName"]);
                            category.Description = Convert.ToString(reader["Description"]);
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            return category;
        }
        private void FormClear()
        {
            txtCategoryName.Text="";
            txtCategoryDescription.Text = "";
        }
        public bool FormInsert(Category item)
        {
            string sql = @"INSERT INTO Categories(CategoryName,Description)
VALUES
(@CategoryName, @Description)";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CategoryName", item.CategoryName);
                        command.Parameters.AddWithValue("Description", item.Description);

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

        public bool FormUpdate(Category item)
        {
            string sql = @"UPDATE dbo.Categories SET 
                            CategoryName = @CategoryName,
                            Description = @Description
                            where CategoryID=@CategoryID";


            bool result = false;
            using (SqlConnection con = new SqlConnection(_ConnectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, con))
                    {
                        command.Parameters.AddWithValue("CategoryName", item.CategoryName);
                        command.Parameters.AddWithValue("Description", item.Description);
                        command.Parameters.AddWithValue("CategoryID", item.CategoryID);
    
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
            var category = new Category();
            category.CategoryID = this.RecId;
            category.CategoryName = this.txtCategoryName.Text;
            category.Description = this.txtCategoryDescription.Text;


            if (this.RecId == 0)
            {

                if (FormInsert(category))
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

                if (FormUpdate(category))
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
        public bool FormDelete()
        {
            bool result = false;
            var dialog = MessageBox.Show("Kategoriyi silmek istediğinizden emin misiniz?", "Kategori Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                using (SqlConnection con = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("DELETE dbo.Categories WHERE CategoryID = @CategoryID", con))
                        {
                            command.Parameters.AddWithValue("CategoryID", this.RecId);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
