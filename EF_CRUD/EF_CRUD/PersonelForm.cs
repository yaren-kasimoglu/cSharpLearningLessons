using EF_CRUD.Core.Model;
using EF_CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_CRUD
{
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }

     
        private void PersonelForm_Load(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {
            FillData();
            FillControl();
        }

        private void FillData()
        {
            int employeeId = Convert.ToInt32(this.Tag);
            if (employeeId > 0)
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    var employee = db.Employees.FirstOrDefault(t0 => t0.EmployeeId == employeeId);
                    if (employee != null)
                    {
                        txtFirstName.Text = employee.FirstName;
                        txtLastName.Text = employee.LastName;
                        txtTitlee.Text = employee.Title;
                        txtTitleOfCourtesy.Text = employee.TitleOfCourtesy;
                        dtBirthDate.Value = Convert.ToDateTime(employee.BirthDate);
                        dtHireDate.Value = Convert.ToDateTime(employee.HireDate);
                        txtRegion.Text = employee.Region;
                        txtPostalCode.Text = employee.PostalCode;
                        txtCountry.Text = employee.Country;
                        txtCity.Text = employee.City;
                        txtAddress.Text = employee.Address;
                        cmbReportsTo.SelectedValue = employee.ReportsTo;
                    }
                }
            }
        }

        private void FillControl()
        {
            FillreportsTo();
        }


        private void FillreportsTo()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                var employeKeyValueList = db.Employees.Select(t0 => new KeyValue(t0.EmployeeId, t0.FirstName + " " + t0.LastName)).ToList();
                cmbReportsTo.DisplayMember = "Value";
                cmbReportsTo.ValueMember = "Id";
                cmbReportsTo.DataSource = employeKeyValueList;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();

        }

        private void FormDelete()
        {
            if (this.Tag!=null)
            {
                var dialog = MessageBox.Show("Seçilen kaydı silmek istiyor musunuz?","PErsonel Form", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog==DialogResult.OK)
                {
                    using (NorthwindContext db =new NorthwindContext())
                    {
                        try
                        {
                            int employeeId = Convert.ToInt32(this.Tag);
                            var employee=db.Employees.FirstOrDefault(t => t.EmployeeId == employeeId);
                            if (employee != null)
                            {
                                db.Employees.Remove(employee);
                                db.SaveChanges();
                                MessageBox.Show("İşlem Başarılı");
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void FormClear()
        {
            this.Tag = 0;
            this.txtAddress.Text = "";
            this.txtCity.Text = "";
            this.txtCountry.Text = "";
            this.txtRegion.Text = "";
            this.txtFirstName.Text = "";
            this.txtLastName.Text = "";
            this.txtTitlee.Text = "";
            this.txtTitleOfCourtesy.Text = "";
            this.dtBirthDate.Value = DateTime.Now;
            this.dtHireDate.Value = DateTime.Now;
            this.txtPostalCode.Text = "";
            cmbReportsTo.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {
                using (NorthwindContext db = new NorthwindContext())
                {
                    Employee personal;
                    int EmployeeId = Convert.ToInt32(this.Tag);

                    if (EmployeeId == 0)
                    {//insert
                        personal = new Employee();
                        db.Employees.Add(personal);
                    }

                    else
                    {
                        personal = db.Employees.FirstOrDefault(t0 => t0.EmployeeId == EmployeeId);
                    }

                    if (personal != null)
                    {
                        personal.FirstName = txtFirstName.Text;
                        personal.LastName = txtLastName.Text;
                        personal.Title = txtTitlee.Text;
                        personal.TitleOfCourtesy = txtTitleOfCourtesy.Text;
                        personal.BirthDate = dtBirthDate.Value;
                        personal.HireDate = dtHireDate.Value;
                        personal.Region = txtRegion.Text;
                        personal.Address = txtAddress.Text;
                        personal.PostalCode = txtPostalCode.Text;
                        personal.Country = txtCountry.Text;
                        personal.City = txtCity.Text;
                        if (cmbReportsTo.SelectedIndex >-1)
                        {
                            personal.ReportsTo = (cmbReportsTo.SelectedItem as KeyValue).Id;
                        }
                    }
                    db.SaveChanges();

                    this.Tag = personal.EmployeeId;
                    MessageBox.Show("işlem başarılı");
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }

        }



    }
}