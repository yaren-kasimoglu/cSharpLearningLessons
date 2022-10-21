using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CodeFirst_Application.DAL.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
