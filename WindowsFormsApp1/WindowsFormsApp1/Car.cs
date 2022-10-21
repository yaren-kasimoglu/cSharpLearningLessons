using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Car
    {

        List<Car> team = new List<Car>();

        Deneme d = new Deneme();

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {

                if (_gender == "k")
                {
                    _gender = value;
                    Console.WriteLine("Kadın");
                }
                else if (_gender == "e")
                {
                    _gender = value;
                    Console.WriteLine("Erkek");
                }
                else
                {
                    throw new Exception("k veya e dışında değer girmeyiniz");
                }



            }
        }
        private DateTime _dateOfBirtg;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirtg; }
            set
            {

                if (_dateOfBirtg <= DateTime.Now)
                {

                 _dateOfBirtg = value;
                }
                else
                {
                    throw new Exception("İleri tarihli değer giremezsiniz tarih bilgisini kontrol ediniz.");
                }

            }
        }

        public string    FirstName { get; set; }
        public string LastNAme { get; set; }

        public Car(string firtName, string lastName)
        {
            this.FirstName = firtName;
            this.LastNAme = lastName;
        }


    }

    public class Seat
    {
        public Seat(int number)
        {

        }

        public int Number { get;}
        public Car Car { get; set; }
    }
}
