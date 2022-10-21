using Linq_Example.Models;

namespace Linq_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NorthwindContext db=new NorthwindContext())
            {
                var result = db.Employees.First();
                var result2 = db.Employees.First();
            }
        }
    }
}