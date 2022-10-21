using EF_CoreIntro.DAL.Context;

namespace EF_CoreIntro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       EFContext context=new EFContext();
        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            dataGridView1.DataSource=context.Customers.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=context.Categories.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=context.Products.ToList(); 
        }
        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=context.Shippers.ToList();
        }
    }
}