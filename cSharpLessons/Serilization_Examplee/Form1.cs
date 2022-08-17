using Serilization_Examplee.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serilization_Examplee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fillcolor();
        }

        private void Fillcolor()
        {
            cmbColor.Items.AddRange(Enum.GetNames(typeof(KnownColor)));
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.FromName(cmbColor.Text);
        }

        private void btnFormConfigsave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Lütfen bir dosya konumu seçiniz";
            saveFileDialog.Filter = "ayar dosyası | *.ayar";
            saveFileDialog.DefaultExt = "*.ayar";

            //Kullanıcı dosya konumunu seçmedi ise aşağıya koda devam etme
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                FormConfig formConfig = new FormConfig();

                formConfig.Text = this.Text;
                formConfig.Widht = this.Width;
                formConfig.Height = this.Height;
                formConfig.BackColor = this.BackColor;

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate)) //open or create: file modu açma veya oluşturma olsun
                {
                    //serileştirme
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, formConfig);
                    MessageBox.Show("işlem başarılı");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnOkuconfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Lütfen bir ayar dosyası seçiniz";
            //uzantıları filtrelemesi için filter kullanıyoruz
            openFileDialog.Filter = "Ayar dosyası |*.ayar";
            //dosya seçimi olmadı ise aşağıdaki kodları çalıştırma
            if (openFileDialog.ShowDialog() != (DialogResult.OK)) return;

            try
            {
                using (FileStream fs=new FileStream(openFileDialog.FileName,FileMode.OpenOrCreate))
                {
                    //deserialize işlemi
                    BinaryFormatter formatter=new BinaryFormatter();    
                    var ayarDosyasi=(FormConfig)formatter.Deserialize(fs);
                    this.Text = ayarDosyasi.Text;
                    this.BackColor = ayarDosyasi.BackColor;
                    this.Height = ayarDosyasi.Height;
                    this.Width = ayarDosyasi.Widht;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnjson_Click(object sender, EventArgs e)
        {

        }
    }
}
