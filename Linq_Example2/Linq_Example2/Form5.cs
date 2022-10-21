using Linq_Example2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_Example2
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //skip=> koleksiyon içerisinde bulunan verilerin başlangıç indexini belirler. Belirlenen index numarasından sonraki verileir getirir.
            //take=> koleksiyon içöeriisnden lisytelenecek olan verileri adedini belirler. SQL sorgu cümleciğinde top anahtar sözcüğü eşdeğerdir.

            using (NorthwindContext db = new NorthwindContext())
            {
                var result = db.Orders.Take(10).Skip(0).ToList();
                dataGridView1.DataSource = result;
            }
        }
    }
}
