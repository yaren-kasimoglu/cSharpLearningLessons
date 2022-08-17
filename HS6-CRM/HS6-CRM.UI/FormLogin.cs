using HS6_CRM_BL.Abstract;
using HS6_CRM_BL.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HS6_CRM.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            userService = new UserAccountService();
        }

        IUserAccountBusiness userService = null;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            var user = userService.GetUser(userName, password);

            if (user != null)
            {
                FormMain form = new FormMain();
                form.ShowDialog();
            }
            else
            {
                UIHelper.ErrorMessage("Kullanıcı adı veya şifre hatalı");
            }


        }
    }
}
