using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Seat
    {
        public Seat(int number)
        {
            this.Number = number;
        }

        public int Number { get; }
        public Person Passanger { get; set; }
        private bool _doluMu;

        public bool DoluMu
        {
            get { return _doluMu; }
            set {

                if (_doluMu==true)
                {
                    _doluMu = value;
                    Console.WriteLine("Dolu");
                 
                }
                else
                {
                    _doluMu = false;
                }
               
            
            }
        }

    }
}
