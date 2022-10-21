using EF_CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CRUD
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
      
        private void AdminLogin_Load(object sender, EventArgs e)
        {
          
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            try
            {
                using (NorthwindContext db=new NorthwindContext())
                {
                    LoginAccount log =new LoginAccount();
                    log=db.LoginAccounts.Where(x => x.UserName == txtAdminName.Text && x.Pass==txtPassword.Text).SingleOrDefault();

                    if (log!=null)
                    {
                        MessageBox.Show("Giriş Başarılı");
                        NorthwindMainForm mainForm=new NorthwindMainForm();
                        mainForm.Show();
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
        
    }
}
