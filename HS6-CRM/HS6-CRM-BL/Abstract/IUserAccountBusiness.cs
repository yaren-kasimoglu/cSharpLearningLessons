using HS6_CRM_Enttities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_BL.Abstract
{
    public interface IUserAccountBusiness
    {
        void Insert(UserAccount item);
        void Update(UserAccount item);
        bool Delete(int id);
        UserAccount GetById(int id);
        List<UserAccount> GetAll();
        UserAccount GetUser(string username,string password);

    }
}
