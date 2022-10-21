using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CRUD.Core.Model
{
    public class KeyValue
    {
        public KeyValue(int _id, string _value)
        {
            this.Id =_id;
            this.Value = _value;
        }
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
