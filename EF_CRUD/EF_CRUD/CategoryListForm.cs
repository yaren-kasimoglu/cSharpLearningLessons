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
    public partial class CategoryListForm : Form
    {
        public CategoryListForm()
        {
            InitializeComponent();
        }
        private void CategoryListForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillGridLayout();
            FillCategories();
        }

        private void FillCategories()
        {
            using (NorthwindContext db=new NorthwindContext())
            {
                var categories = db.Categories.ToList();
                dataGridView1.DataSource = categories;
            }
        }

        public DataGridViewColumn GenerateColumn(string name, string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName = name;
            column.HeaderText = caption;
            return column;
        }
        private void FillGridLayout()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(GenerateColumn("CategoryName", "Kategori Adı"));
            dataGridView1.Columns.Add(GenerateColumn("Description", "Kategori Açıklama"));
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int categoryId = ((dataGridView1.DataSource as List<Category>)[e.RowIndex]).CategoryId;
            var form = new CategoryForm();
            form.Tag=categoryId;
            form.ShowDialog();
            FillCategories();
        }

     
    }
}
