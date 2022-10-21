using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_CRUD.DAL.Entities
{
    public class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
        }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        //navigation property

        public List<City> Cities { get; set; }
    }
}
