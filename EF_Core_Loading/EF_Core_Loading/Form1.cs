using EF_Core_Loading.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Loading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Ef core  Loading çeşitleri
        //EagerLoading => ihtiyacımız olmasa da yükleme işlemi
        //Lazy Loading => yavaş yükleme olarak düşünebiliriz. temel amaç: başvuru yapıldıktan sonra yükleme
        //Explicit Loading  => 

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //eager loading => kullanacağımız nesneleri, ihtiyaç anından çok önce yaratır ve bekletir. Biz o nesneye başvuru yapmadan önce yüklenmiş olur
            using (var db = new ExampleContext())
            {
                var result = db.Customer.Include(x => x.Orders).FirstOrDefault(t => t.Id == 1); // id si 1 olan müşterileri siparişleriyle beraber yükle

                MessageBox.Show(result.CustomerName);

                foreach (var order in result.Orders)
                {
                    MessageBox.Show(order.OrderNumber);
                }
            }
        }

        //lazy loading ben başvurmadıkça veritabanına gereksiz sorgu atmayacağı için daha performanslı olabiliyor bazı durumlarda. İhtiyaç olmadan yükleme yapmak performans açısından sıkıntı yaratabilir. Ama hangisinin kullanılması gerektiğine probleme göre karar verilmesi gerekir.

        private void button2_Click(object sender, EventArgs e)
        {
            // lazy loading => başvuru anında yükleme. ihtiyacm oılmadan bana bir şey getirme demek.
            using (var db = new ExampleContext())
            {
                var result = db.Customer.FirstOrDefault(x => x.Id == 2);
                foreach (var order in result.Orders)
                {
                    MessageBox.Show(order.OrderNumber);
                }

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Explicit Loading => 

            using (var db = new ExampleContext())
            {
                var result = db.Customer.FirstOrDefault(t => t.Id == 3);

                db.Entry(result).Collection(x => x.Orders).Load();
                db.Entry(result).Reference(x => x.Orders).Load();

                MessageBox.Show(result.CustomerName);

                foreach (var order in result.Orders)
                {
                    MessageBox.Show(order.OrderNumber);
                }

            }
        }
    }
}