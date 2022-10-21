using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_CRUD.DAL.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public int CountryId { get; set; } //navigation property
        public virtual Country Country { get; set; }  //foreign key
    }
}
