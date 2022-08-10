using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplications
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            string userName=txtUserName.Text;
            string passWord=txtPassword.Text;

            if (userName=="admin"&&passWord=="1234")
            {
                MessageBox.Show("Giriş Başarılı");
            }
        }
    }
}
