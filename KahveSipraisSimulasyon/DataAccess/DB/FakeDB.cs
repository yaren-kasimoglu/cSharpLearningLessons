using CustomerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DB
{
    public class FakeDB
    {
        private static int _coffeId = 0;

        List<Coffees> CoffeesList;
        public FakeDB()
        {
            CoffeesList = new List<Coffees>();
            SeedData();
        }

        private void SeedData()
        {
            CoffeesList.Add(new Coffees() { Id = NextUserAccountId(), PreparationTime = 3.50, Score = 8, Type="Hot Coffee"});
            CoffeesList.Add(new Coffees() { Id = NextUserAccountId(), PreparationTime = 4.0, Score = 7,Type="Cold Coffee"});
        }

        public List<Coffees> Coffees
        {
            get { return CoffeesList; }
        }

        public int NextUserAccountId()
        {
            return _coffeId + 1;
        }
    }
}
