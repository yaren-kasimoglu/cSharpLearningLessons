using HS6_CRM_Enttities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_DAL.Abstract
{
    public interface IUserAccountRepository :IRepository<UserAccount> //UserAccount için ek işlem eklemek istiyorsak buraya ekleyeceğiz
    {
       UserAccount GetUser(string username, string password);
    }
}
