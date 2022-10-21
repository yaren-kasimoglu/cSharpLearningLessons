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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillData();

        }

        private void FillData()
        {
            int categoryId = Convert.ToInt32(this.Tag);
            if (categoryId > 0)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
                    if (category != null)
                    {
                        category.CategoryId = categoryId;
                        category.CategoryName = txtCategoryName.Text;
                        category.Description = txtCategoryDescp.Text;
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
            this.txtCategoryDescp.Text = "";
            this.txtCategoryName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                using (NorthwindContext db =new NorthwindContext())
                {
                    Category category;
                    int categoryID=Convert.ToInt32(this.Tag);
                    if (categoryID==0)
                    {
                        category = new Category();
                        db.Categories.Add(category);
                    }
                    else
                    {
                        category=db.Categories.FirstOrDefault(c => c.CategoryId == categoryID);
                    }
                    if (category!=null)
                    {
                        category.CategoryName = txtCategoryName.Text;
                        category.Description=txtCategoryDescp.Text;
                    }
                    db.SaveChanges();

                    this.Tag = category.CategoryId;
                    MessageBox.Show("işlem başarılı");
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
            if (this.Tag != null)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?", "PErsonel Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    using (NorthwindContext db = new NorthwindContext())
                    {
                        try
                        {
                            int catgoryID = Convert.ToInt32(this.Tag);
                            var category = db.Categories.FirstOrDefault(c => c.CategoryId == catgoryID);
                            if (category != null)
                            {
                                db.Categories.Remove(category);
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
