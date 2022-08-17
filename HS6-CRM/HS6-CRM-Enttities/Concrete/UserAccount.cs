using HS6_CRM_Enttities.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_Enttities.Concrete
{
    public class UserAccount : IEntity
    {
        public int UserAccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; } //kullanıcı adı dışında real ismi
        public DateTime RecordDate { get; set; } //kayıt zamanı
        public DateTime ModifiedDate { get; set; } //kaydın son güncellenme zamanı
    }
}