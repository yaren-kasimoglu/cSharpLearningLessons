using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    public class Course
    {
        public Course()
        {
            this.StudentCourse = new List<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }


        //Bir kursta biden faz öğrenci bulunabilir mi? Eet ise aşağıdaki satırı yaz,  yani navigation property
        public virtual List<StudentCourse> StudentCourse { get; set; } //bir öğrencinin birden fazla kursu olabilir. bunu liste vererek söylemiş oluyoruz

        //iki tablo birbirini tanımıyor, aradaki tablo üzerinden gideceğiz
    }
}
