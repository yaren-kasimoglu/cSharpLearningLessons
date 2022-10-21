using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<Product> HotCoffeeList = new List<Product>();
        List<Product> ColdCoffeeList = new List<Product>();
        List<Employee> EmployeeList = new List<Employee>();
        List<Order> Orders=new List<Order>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            FillData();

        }

        private void FillData()
        {
            FillHotCoffee();
            FillColdCoffee();
            FillEmploye();
        }

        /// <summary>
        /// soğuk kahve çeşidi doldurma
        /// </summary>
        private void FillColdCoffee()
        {

            ColdCoffeeList.Clear();
            ColdCoffeeList.Add(new Product { ProductName = "Cold Americano", PreparationTime = 2.0, Score = 6 });

            
        }
        /// <summary>
        /// sıcak kahve çeşidi doldurma
        /// </summary>
        private void FillHotCoffee()
        {
            HotCoffeeList.Clear();
            HotCoffeeList.Add(new Product { ProductName = "Filtre Kahve", PreparationTime = 3.5, Score = 8 });

        }
        /// <summary>
        /// çalışanlar listesini doldurma ve görme
        /// </summary>
        private void FillEmploye()
        {
            EmployeeList.Clear();
            EmployeeList.Add(new Employee { EmployeeId = 1, EmployeePlace = "Kasa" });
            EmployeeList.Add(new Employee { EmployeeId = 2, EmployeePlace = "Üretim" });
            EmployeeList.Add(new Employee { EmployeeId = 3, EmployeePlace = "Kasa" });
            EmployeeList.Add(new Employee { EmployeeId = 4, EmployeePlace = "Üretim" });

        }

        private voif Fillcomboemployee()
        {
            FillDataSource<Employee>(cmbEmployee, EmployeeList);
        }
        private void FillComboColdCoffee()
        {
            FillDataSource<Product>(cmbColdCoffee, ColdCoffeeList);
        } 
        private void FillCombohotCoffee()
        {
            FillDataSource<Product>(cmbHotCoffee, HotCoffeeList);
        }
     

        /// <summary>
        /// aşağıdkai metod verileri bir combo box gibi bir yerde tutup listelediğimizi varsayarak yazılan metoddur 
        /// </summary>
        private void FillDataSource<T>(ComboBox comboBox,List<T> datalist )
        {
            cmb.Items.Clear();
            foreach (var item in datalist)
            {
                cmb.Items.Add(items);

            }
            cmb.SelectedIndex = 0;//ilk eleman seçili gelsin diye
        }

        public void btnChoses_Click(object sender,EventArgs e)
        {
            var order = new Order();

            if (cmbHotCoffee.SelectedIndex>-1)
            {
                order.HotCoffee = (Product)cmbHotCoffee.SelectedItem;
            }
            if (cmbColdCoffee.SelectedIndex > -1)
            {
                order.ColdCoffee = (Product)cmbColdCoffee.SelectedItem;
            }


            if (rdbmilk1.Checked)
            {
                order.Milk = 1;
            }
            else
            {
                order.Milk = 2;
            }

            Orders.Add(order);

        }

        /// <summary>
        /// seçilen çalışan kasada olacak dierleri ürewtimde
        /// </summary>
    
        public void btnEmployee_Click(object sender, EventArgs e)
        {
            var employee=new Employee();

            if (rdbEmp1.Checked)
            {
                employee.EmployeePlace = "Kasa"; 
            }
            else if (rdbEmp2.Checked)
            {
                employee.EmployeePlace = "Kasa";
            }
           else if (rdbEmp3.Checked)
            {
                employee.EmployeePlace = "Kasa";
            }
            else
            {
                employee.EmployeePlace = "Kasa";
            }

            

        }

    }
}
