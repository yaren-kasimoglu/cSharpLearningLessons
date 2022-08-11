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
    public partial class Form1 : Form
    {
       
        DataTable tablo = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }
        List<Personel> personels = new List<Personel>();

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.ShowDialog();
            if (newUser.SelectedPersonel!=null)
            {
               personels.Add(newUser.SelectedPersonel);
            }

            GridDoldur();

        }
       public void Form1_Load(object sender, EventArgs e)
        {
            //tablo.Columns.Add("Ad Soyad", typeof(string));
            //tablo.Columns.Add("Doğum yılı", typeof(string));
            //tablo.Columns.Add("Telefon Numarası", typeof(string));
            //tablo.Columns.Add("Email", typeof(string));
            //tablo.Columns.Add("Adres", typeof(string));
            //tablo.Columns.Add("Cinsiyet", typeof(string));
            //tablo.Columns.Add("Maaş", typeof(string));
            //tablo.Columns.Add("Okul", typeof(string));
            //tablo.Columns.Add("Şehir", typeof(string));
          
            //dGVKullaniciListesi.DataSource = tablo;

        }

        public void GridDoldur()
        {
            dGVKullaniciListesi.DataSource = null;
            dGVKullaniciListesi.DataSource = personels;

        }
      
    }
}
