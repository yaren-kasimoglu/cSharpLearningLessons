using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryForm.Model
{
    public class Student
    {
        /// <summary>
        /// kaydın programatik olaran sistem tarafından verilen id numarasıdır
        /// </summary>


        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        private string _TcNo;

        public string TcNo
        {
            get { return _TcNo; }
            set { _TcNo = value; }
        }
        private string _NameSurname;

        public string NameSurname
        {
            get { return _NameSurname; }
            set { _NameSurname = value; }
        }

        private string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _ClassNumber;

        public string ClassNumber
        {
            get { return _ClassNumber; }
            set { _ClassNumber = value; }
        }

        private bool _Gender;

        public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        public override string ToString()
        {
            return $"{ this.Id}-{ this.NameSurname}";
        }

    }
}
