using StockManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm form = new RegisterForm();
            form.Show();
            this.Hide();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (StockAppContext db = new StockAppContext())
                {
                    LoginControl loginControl = new LoginControl();
                    loginControl = db.LoginControls.Where(l => l.UserName == txtUserLoginName.Text && l.Passw == txtUserLoginPass.Text).SingleOrDefault();
                    if (loginControl != null)
                    {
                        //AÇILACAK SAYFA BİLGLİERİ
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Giriş Bilgileri Hatalı");
            }

        }
    }
}
