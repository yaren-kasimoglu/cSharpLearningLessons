using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnumOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillForm();
        }
        private void FillForm()
        {
            cmbDepartman.Items.AddRange(Enum.GetNames(typeof(Departman)));    //get names ile enum içerisindeki tanımlı olan değerleri alabilriz
            cmbDepartman.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Personel personel = new Personel();
            //personel.AdiSoyadi=txtNameSurname.Text;

            ////combodan seçilen değeri enum içerisinde hangi değere karşılık geliyor ise o değeri onun tipinde alabiliriz
            //personel.Departman=(Departman)Enum.Parse(typeof(Departman),cmbDepartman.Text);

            ////enum için o değerde value olarak ne tutuyor ise onu alabilirsiniz
            //int selectedDepartmanValue = (int)Enum.Parse(typeof(Departman), cmbDepartman.Text);

            Departman selectedTryParseValue;
            bool result=Enum.TryParse<Departman>(cmbDepartman.Text, out selectedTryParseValue); //dönüştürebiliyorsa atama yapar dönüştüremezse defaultt değerde kalır
            if (result)
            {
                MessageBox.Show("Personelin departmanı" + selectedTryParseValue.ToString());
            }
            else
            {
                MessageBox.Show("departman değeri okunamadı ");
            }
        }
    }
}
