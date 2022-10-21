using StockManagement.Core.Model;
using StockManagement.Models;
using System;
using System.Collections.Generic;

namespace StockManagement.Models
{
    public partial class LoginControl
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Passw { get; set; } = null!;
        public int? PositionId { get; set; }

        public virtual Position? Position { get; set; }
    }
}

//using StockManagement.Core.Model;
//using StockManagement.Models;

//namespace StockManagement
//{
//    public partial class RegisterForm : Form
//    {
//        public RegisterForm()
//        {
//            InitializeComponent();
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            FormSave();
//        }

//        private void Position()
//        {
//            using (StockAppContext db = new StockAppContext())
//            {
//                var positionList = db.Positions.Select(t0 => new KeyValue(t0.PositionId, t0.PositionRole)).ToList();
//                cmbPosition.DisplayMember = "Value";
//                cmbPosition.ValueMember = "Id";
//                cmbPosition.DataSource = positionList;
//            }
//        }

//        private void FormSave()
//        {
//            try
//            {
//                using (StockAppContext db = new StockAppContext())
//                {
//                    LoginControl log = new LoginControl();

//                    log.FirstName = txtfirstName.Text;
//                    log.LastName = txtLastName.Text;
//                    log.UserName = txtUserName.Text;
//                    if (cmbPosition.SelectedIndex > -1)
//                    {
//                        log.PositionId = (cmbPosition.SelectedItem as KeyValue).Id;
//                    }

//                }
//            }
//            catch (Exception ex)
//            {

//                MessageBox.Show(ex.Message);
//            }
//        }
//    }
//}