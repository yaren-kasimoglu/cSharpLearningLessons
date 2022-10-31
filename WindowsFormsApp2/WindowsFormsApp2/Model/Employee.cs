using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    public class Employee
    {
        /// <summary>
        /// Çalışanları ıd ye göre çağırmak için
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// kasa mı üretim mi konum belirlemek için
        /// </summary>
        public string EmployeePlace { get; set; }
    }
}
