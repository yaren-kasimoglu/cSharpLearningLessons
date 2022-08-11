using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelKayitUygulamasi
{
    
    public partial class NewUser : Form
    {
        Form1 form1=new Form1();
        public NewUser()
        {
            InitializeComponent();
        }
        public Personel SelectedPersonel { get; set; }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            
            PersonelBilgiDoldur();

        }

        public  void PersonelBilgiDoldur()
        {
            Personel personel = new Personel();
            personel.NameSurname = txtİsimSoyisim.Text;
            personel.DateofBirth = dateTimePicker1.Value;
            personel.TelNo = txtTelefon.Text;
            personel.eMail = txtEmail.Text;
            personel.Adress = txtAdres.Text;
            if (rdbKadin.Checked)
            {
                personel.Gender = rdbKadin.Text;
            }
            else if (rdbErkek.Checked)
            {
                personel.Gender = rdbErkek.Text;
            }
            else
            {
                MessageBox.Show("Lütfen Cinsiyet Seçimi Yapiniz");
            }

            personel.Salary=txtMaas.Text;

            if (rdbilkokul.Checked)
            {
                personel.LevelofSchool = rdbilkokul.Text;
            }
            else if (rdbOrtaOkul.Checked)
            {
                personel.LevelofSchool = rdbOrtaOkul.Text;
            }
            else if (rdbLise.Checked)
            {
                personel.LevelofSchool = rdbLise.Text;
            }
            else if (rdbUniversite.Checked)
            {
                personel.LevelofSchool = rdbUniversite.Text;
            }
            else if (rdbyuksekLisans.Checked)
            {
                personel.LevelofSchool = rdbUniversite.Text;
            }
            else if (rdbDoktora.Checked)
            {
                personel.LevelofSchool = rdbDoktora.Text;
            }
            else
            {
                MessageBox.Show("Lütfen okul seçiminizi yapın");

            }
            personel.Hometown = cmbDogumYeri.Text;

            this.SelectedPersonel = personel;
            this.Close();
        }
    }
}
