using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bus
    {
        public readonly int seatCount = 50;
        public Bus(int seatCount)
        {
            this.seatCount = seatCount;

            for (int i = 0; i < seatCount; i++)
            {
                int seatNumber = i + 1;

                Seat seat = new Seat(seatNumber);
                Seats.Add(seat);
            }
        }

        public Person Driver { get; set; }

        private List<Seat> _Seats;
        public List<Seat> Seats
        {
            get { return _Seats; }
            set { _Seats = value; }
        }

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
    }
}