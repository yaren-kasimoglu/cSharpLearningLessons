using PlakDukkani_MaratonEFCore.DAL.Context;
using PlakDukkani_MaratonEFCore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PlakDukkani_MaratonEFCore
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private string PasswordHash(string sifre)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sifre)).Select(l => l.ToString("X2")));
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                using (PlakDbContext db = new PlakDbContext())
                {
                    Admin admin;
                    int adminId = Convert.ToInt32(this.Tag);
                    if (adminId == 0)
                    {
                        admin = new Admin();
                        db.Admin.Add(admin);
                    }
                    else
                    {
                        admin = db.Admin.SingleOrDefault(a => a.Id == adminId);
                    }

                    if (admin != null)
                    {
                        admin.AdminName = txtUserNameReg.Text;
                        admin.Password = PasswordHash(txtPasswordReg.Text);
                    }

                    if (txtPasswordReg.Text == txtPasswordAgainReg.Text)
                    {
                        if (vaildate_password.IsMatch(txtPasswordReg.Text) != true)
                        {
                            MessageBox.Show("Parolanız en az 8 karakter uzunluğunda olmalıdır.\nEn az 2 büyük harf içermelidir.\nEn az 3 küçük harf içermelidir.\n(*, :, !, +) karakterlerinden an az 2 tane içermelidir ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //b,r büyük harf ve iki küçük harf ve bir karakter girince de çalışıyor örn: 123456Aaa* girerseniz şifreyi kayıt alacaktır.
                            txtPasswordReg.Focus();
                            return;
                        }
                        else
                        {
                            db.SaveChanges();
                            MessageBox.Show("işlem başarılı");
                            this.Hide();
                            var form = new Giris();
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz şifreler uyuşmuyor. Lütfen girdiğiniz şifreleri kontrol ediniz.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\n !!!Aynı kullanıcı adına sahip bir admin hesabı bulunmaktadır.!!!");
            }
        }

        private static Regex PasswordValidation()
        {
            string pattern = "^.*(?=.{8,})(?=.*\\d)(?=.*[a-z].{3,})(?=.*[A-Z].{2,})(?=.*[!*:+]).*$";
            //string pattern = "^.*(?=.{8,})(?=.*\\d)(?=.*[a-z].{4})(?=.*[A-Z].{3})(?=.*[!*:+].{3}).*$";
            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex vaildate_password = PasswordValidation();

    }
}

