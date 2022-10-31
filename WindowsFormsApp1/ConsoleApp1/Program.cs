using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Seat seat = new Seat(5);
            Console.WriteLine(seat);

            Console.ReadKey();
            

            Bus bus = new Bus(50);
            bus.Seats.Add(seat);
            bus.Seats.Add(seat);
            seat.DoluMu = true;
           
            
 
   
        }
    }
}
