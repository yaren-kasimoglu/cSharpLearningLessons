using DictionaryForm.Model;
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
        int id = 0;

        Student selectedStudent; //değişken tanımlaması

        //Öğrenci listesi
        ArrayList studentList = new ArrayList();

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

        /// <summary>
        /// ekrandaki bütün kontrolleri temizlemek için kullanılacak
        /// </summary>
        private void FormClear()
        {
            txtTc.Text = "";
            txtAdSoyad.Text = "";
            txtMail.Text = "";
            cmbSinif.SelectedIndex = 0;

            //ekranı boşaltırken eğer seçili bir nesne var ise onu da null set et
            selectedStudent = null;

        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormSave()
        {
            Student student = null;

            if (selectedStudent != null)
            {
                //seçilen nesneyi al
                student = selectedStudent;
            }
            else
            {
                //yeni bir instance al
                student = new Student();
                student.Id = GetId();
                studentList.Add(student);
            }

            student.NameSurname = txtAdSoyad.Text;
            student.Email = txtMail.Text;
            student.TcNo = txtTc.Text;

            student.ClassNumber = cmbSinif.SelectedItem.ToString();
            if (rdbErkek.Checked)
            {
                student.Gender = true;
            }
            else
            {
                student.Gender = false;
            }

            RefreshListbox();

            FormClear();

        }
        private void RefreshListbox()
        {
            lstOgrenciler.Items.Clear();
            foreach (var student in studentList)
            {
                lstOgrenciler.Items.Add(student);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FormValid())
            {
                FormSave();
            }
            
        }  
        private bool FormValid()
        {
            bool result = true;
            if (string.IsNullOrWhiteSpace(txtTc.Text))
            {
                MessageBox.Show("Tc kimlik no alanını doldurun", "Öğrenci Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTc.Focus();
                result = false;
            }
            return result;
        }

        private int GetId()
        {
            return ++id;
        }

        private void lstOgrenciler_DoubleClick(object sender, EventArgs e)
        {
            if (lstOgrenciler.SelectedIndex == -1)
            {
                return;
            }
            //ben listbox içerisindeki item student nesnesini attım
            // boxing unboxing olayını yapıyorum ve seçilen item bir öğrencidir diyorum

            selectedStudent = lstOgrenciler.SelectedItem as Student;

            //seçilen student bilgilerini tekrardan ekrana bassın (güncellendikten sonra)
            FillRecordForm();
        }

        private void FillRecordForm()
        {
            txtTc.Text = selectedStudent.TcNo;
            txtAdSoyad.Text = selectedStudent.NameSurname;
            txtMail.Text = selectedStudent.Email;

            if (selectedStudent.Gender == true)
            {
                rdbErkek.Checked = true;
            }
            else
            {
                rdbKadin.Checked = true;
            }

        }

        private void RecordRemove()
        {
            if (selectedStudent!=null)
            {
                var dialogResult = MessageBox.Show("Kaydı silmek istiyor musunuz", "Öğrenci otomasyyonu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    studentList.Remove(selectedStudent);
                    RefreshListbox();
                    FormClear();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            RecordRemove();
        }
    }
}