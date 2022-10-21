using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    public class StudentAddress
    {
        public int StudentAddressId { get; set; }   //PK Referance Student
        public string? Country { get; set; }
        public string? City { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
