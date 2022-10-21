using Linq_Example2.Models;

namespace Linq_Example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Select => Seçmek

            using (NorthwindContext DB = new NorthwindContext())
            {
                //aşağıdaki iki ifade aynı, syntax ları farklı

                //method syntax--------------------

                var result = DB.Employees.ToList();   //tüm kolonları seç

                var result4 = DB.Employees.Select(t0 => t0.Title).ToList();  //Employee leri seç git içinden Title kolonunu seç

                var result5 = DB.Employees.Select(t0 => new { Name = t0.FirstName, Surname = t0.LastName, Title = t0.Title }).ToList();      //select in içinde birden fazla kolon seçmek istiyorsak ya proje içerisine add ile class ekleyip yapabilirsin yada bu şekilde select in içinde new leyip kolonları tek tek yazarak yapabilirsin.

                // var result6 = DB.Employees.Select(t0 => new PersonalDTO() { Id = t0.EmployeeId, FirstName = t0.FirstName }).ToList();   //istersen tip oluştur tolist yap


                ///////////////////////////////////////////////////////////////////////////////////////////////////

                //Query syntax-----------------

                var result3 = (from t0 in DB.Employees     //tüm kolonları seç
                               select t0).ToList();


                //anonymust typr = bilinmeyen type anlamına gelir. İşlem sırasında üretilir.
                var result5_ = (from t0 in DB.Employees  //result list<anonymust type> döner. liste şeklinde
                                select new
                                {
                                    Name = t0.FirstName,
                                    Surname = t0.LastName,
                                    Title = t0.Title,
                                }).ToList();


                //var result6_ = (from t0 in DB.Employees       //PersonalDTO tipinde, liste şeklinde döner.  Genelde bunu kullan.
                //                select new PersonalDTO()
                //                {
                //                    Id = t0.EmployeeId,
                //                    FirstName = t0.FirstName,
                //                }).ToList();



                //  dataGridView1.DataSource = result6_;



            }

        }
            private void button1_Click(object sender, EventArgs e)
            {
                //Order => Sıralama işlemleri
                using (NorthwindContext DB = new NorthwindContext())
                {
                    //OrderBy ifadesi ASC;
                    var result = DB.Employees.Select(t0 => new { Name = t0.FirstName, Id = t0.EmployeeId }).OrderBy(t0 => t0.Name).ToList();

                    //OrderByDescending  DESC;
                    var result2 = DB.Employees.Select(t0 => new { Name = t0.FirstName, Id = t0.EmployeeId }).OrderByDescending(t0 => t0.Name).ToList();


                    //ikincil sıralaam işlemi
                    //thenby => Bir koleksiyon içerisinde ikincil bir sıralama oluşturmak için kullanılır.
                    //thenByDescending

                    var result3 = DB.Employees.OrderBy(t0 => t0.TitleOfCourtesy).ThenBy(t1 => t1.LastName).ThenBy(t2 => t2.Region).ToList();   //Önce TitleOfCourtesy ye göre sırala,  kendi içerisinde aynı olanları LastName e göre sırala.  Kendi içerisinde aynı olanları Region a göre sırala.   Bu şekilde sıralamayı uzatabilriz.

                    var result4 = DB.Employees.OrderBy(t0 => t0.TitleOfCourtesy).ThenByDescending(t1 => t1.LastName).ToList();   //sıralama TitleOfCourtesy e göre ASC sıralandı, sonra kendi içinde aynı olanlar LastName e göre DESC sıralandı.

                    var result5 = DB.Employees.OrderBy(t0 => t0.TitleOfCourtesy).Reverse().ToList();


                    dataGridView1.DataSource = result4;

                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            using (NorthwindContext db=new NorthwindContext())
            {
                var result = db.Employees.Select(t => t.TitleOfCourtesy=="Ms.").ToList();

                var result2 = db.Employees.Select(t => t.Country == "USA").ToList();

                var result3 = db.Orders.Where(o => o.CustomerId == "HANAR").ToList();

                var result4 = db.Orders.Where(o => o.ShipVia == 1).ToList();





                dataGridView1.DataSource = result;
            }
        }
    } 
}