using CustomerEntity.Concrete;
using DataAccess.Abstract;
using DataAccess.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CoffeesDal : ICoffeesDal
    {
        FakeDB _context;
        public CoffeesDal()
        {
            _context=new FakeDB();
        }

        public Coffees GetCoffe(int Id, double time, int Score)
        {
            return _context.Coffees.FirstOrDefault(t0 => t0.PreparationTime == time && t0.Score == Score);
        }

        public void Insert(Coffees item)
        {
            item.Id = _context.NextUserAccountId();
            _context.Coffees.Add(item);
        }
    }
}
