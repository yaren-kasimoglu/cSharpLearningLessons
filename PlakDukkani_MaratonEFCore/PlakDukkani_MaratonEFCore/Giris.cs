using PlakDukkani_MaratonEFCore.DAL.Context;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System.Security.Cryptography;
using System.Text;

namespace PlakDukkani_MaratonEFCore
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            try
            {
                using (PlakDbContext db = new PlakDbContext())
                {
                    Admin user = new Admin();

                    user = db.Admin.Where(u => u.AdminName == txtUserName.Text && u.Password == PasswordHash(txtPassword.Text)).SingleOrDefault();

                    if (user != null)
                    {                     
                            MessageBox.Show("Giriş Başarılı");
                            MainFormAlbums mainForm = new MainFormAlbums();
                            mainForm.ShowDialog();
                            this.Hide();                 
                   }
                    else
                    {
                        MessageBox.Show("Giriş Hatalı");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            }
        private string PasswordHash(string sifre)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sifre)).Select(l => l.ToString("X2")));
            }
        }


    }
}
