using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core
{
    public abstract class BaseEntity //nesne örneği alınmasın diye abstract yaptık
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
