using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Entities
{
    public class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
        }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public int CityId { get; set; }
        public virtual List<City> Cities { get; set; }

    }
}
