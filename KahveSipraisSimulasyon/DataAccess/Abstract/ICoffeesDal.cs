using CustomerEntity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICoffeesDal:IRepository<Coffees>
    {
        Coffees GetCoffe(int Id, double time, int Score);
    }
}
