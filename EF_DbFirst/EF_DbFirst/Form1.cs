using EF_DbFirst.Models;

namespace EF_DbFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NorthwindContext context = new NorthwindContext();
            var personalList=context.Employees.ToList();
            dataGridView1.DataSource = personalList;
        }
        
    }
}