using ADONET_ConnectedArt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADONET_ConnectedArt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Connection String=> hangi veri kaynağına bağlantı yapacağımızı göstere metinsel bir veridir.
        //Sql Connection=> Sorgularımızı db de execute edebilmek yani çalıştırabilmek için kullanacağımzı nesnedir.
        //Sql Command

        //sql server auth
        string _connectionString = @"Server=DESKTOP-MAKL7QI; Database=Northwind User Id=sa; Password=1;"; //user id ve passwordn de ekleyebiliriz
        string _connectionString1 = @".; Database=Northwind"; // nokta koymak kendi makinama bağlan demek

        //windows aut
        string _connectionString2 = @"Server=DESKTOP-MAKL7QI; Database=Northwind; Trusted_Connection=true;";


        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            //veritabanına bağlantı açıp kapatabilmemize yarayan nesnedir
            SqlConnection con = new SqlConnection(_connectionString2);

            List<Employee> personalList = new List<Employee>();

            try
            {

                SqlCommand command = new SqlCommand("Select * from Employees", con);
                //command.CommandText=sql Cümleciği
                //command.CommandTimeout=sql Cümleciği bağlantı timeour süresi

                if (con.State == ConnectionState.Closed) con.Open();


                //Sql çalıştırıldıktan sonra geriye dönen result set i sql data reader nesnesi üstüne çeker
                SqlDataReader reader = command.ExecuteReader();

               

                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.Id = Convert.ToInt32(reader["EmployeeID"]);
                    employee.FirstName = Convert.ToString(reader["FirstName"]);
                    employee.LastName = Convert.ToString(reader["LastName"]);
                    employee.BirthDate = Convert.ToDateTime(reader["BirthDate"]);

                    personalList.Add(employee);
                }


            }
            catch (Exception ex)
            {


            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            dataGridView1.DataSource = personalList;

        }


    }
}
