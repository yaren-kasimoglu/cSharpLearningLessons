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
    public partial class PersonalList : Form
    {
        public PersonalList()
        {
            InitializeComponent();
        }

        private void PersonalList_Load(object sender, EventArgs e)
        {
            FillForm();

        }

        private void FillForm()
        {
            FillGridLayout();
            FillPersonel();
        }

        private void FillGridLayout()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(GenerateColumn("FirstName","Adı"));
            dataGridView1.Columns.Add(GenerateColumn("LastName","Soyadı"));
            dataGridView1.Columns.Add(GenerateColumn("Title","Ünvan"));
            dataGridView1.Columns.Add(GenerateColumn("BirthDate","Doğum Tarihi"));
       
        }

        private void FillPersonel()
        {
            using (NorthwindContext db =new NorthwindContext())
            {
                var personels = db.Employees.ToList();
                dataGridView1.DataSource = personels;
            }
        }
        public DataGridViewColumn GenerateColumn(string name, string caption)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.DataPropertyName= name;
            column.HeaderText = caption;
            return column;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
     
            int emplopeeId = ((dataGridView1.DataSource as List<Employee>)[e.RowIndex]).EmployeeId;
            var form = new PersonelForm();
            form.Tag= emplopeeId;
            form.ShowDialog();
            FillPersonel();
        }
    }
}
