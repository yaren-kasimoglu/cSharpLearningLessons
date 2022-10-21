using StockManagement.Core.Model;
using StockManagement.Models;

namespace StockManagement
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            FillForm();

        }

        private void FillForm()
        {
            FillPosition();
        }

        private void FillPosition()
        {

            using (StockAppContext db = new StockAppContext())
            {
                var positionList = db.Positions.Select(t0 => new KeyValue(t0.PositionId, t0.PositionRole)).ToList();
                cmbPosition.DisplayMember = "Value";
                cmbPosition.ValueMember = "Id";
                cmbPosition.DataSource = positionList;
            }
        }

     

   
        private void FormSave()
        {
            try
            {
                using (StockAppContext db = new StockAppContext())
                {
                    LoginControl log = new LoginControl();

                    log.FirstName = txtfirstName.Text;
                    log.LastName = txtLastName.Text;
                    log.UserName = txtUserName.Text;
                    if (cmbPosition.SelectedIndex > -1)
                    {
                        log.PositionId = (cmbPosition.SelectedItem as KeyValue).Id;
                    }

                    db.LoginControls.Add(log);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }
    }
}