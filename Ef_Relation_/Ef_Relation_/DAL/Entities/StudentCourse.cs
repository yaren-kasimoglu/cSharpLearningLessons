using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Relation_.DAL.Entities
{
    //Çoka çok ilişki için iki tabloyu birbirine bağlayan üçüncü tablo budur.


    public class StudentCourse
    {

        //Çoka çok ilişki kurmak için her iki tablonunda ıd kısımlarını aldık
        public int StudentId { get; set; }
        public int CourseId { get; set; }



        //navigation property leri yazalım
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}
