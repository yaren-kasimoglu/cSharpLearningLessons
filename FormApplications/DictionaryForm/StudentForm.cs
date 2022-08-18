using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryForm
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        ArrayList classList = new ArrayList()
        {
            "1. Sınıf",
            "2. Sınıf",
            "3. Sınıf",
            "4. Sınıf",
            "5. Sınıf",
        };

        private void StudentForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillClass();
        }

        private void FillClass()
        {
            cmbSinif.Items.Clear();
            foreach (string item in classList)
            {
                cmbSinif.Items.Add(item);
            }
            cmbSinif.SelectedIndex = 0;
        }
    }
}