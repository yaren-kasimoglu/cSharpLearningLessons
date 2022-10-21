using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        //Navigation Property

        public virtual StudentAddress StudentAddress { get; set; }

        public virtual List<StudentCourse> StudentCourse { get; set; } //ir öğrencinin birden fazla kursu olabilir

    }
}
