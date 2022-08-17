using HS6_CRM_BL.Abstract;
using HS6_CRM_DAL.Abstract;
using HS6_CRM_DAL.Concrete;
using HS6_CRM_Enttities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_BL.Concrete
{
    public class UserAccountService : IUserAccountBusiness
    {

        IUserAccountRepository userRepo;
        public UserAccountService()
        {
            userRepo = new UserAccountRepository(); //user account service nin çalışabilmesi için user acoount repository ye ihtiyacı var. Yüksek bağımlılık
        }

        public bool Delete(int id)
        {
            return userRepo.Delete(id);
        }

        public List<UserAccount> GetAll()
        {
            return userRepo.GetAll();
        }

        public UserAccount GetById(int id)
        {
            return userRepo.GetById(id);
        }

        public UserAccount GetUser(string username, string password)
        {
            return userRepo.GetUser(username, password);
        }

        public void Insert(UserAccount item)
        {
            userRepo.Insert(item);
        }

        public void Update(UserAccount item)
        {
            userRepo.Update(item);
        }
    }
}
//business ın yaptığı şey sadece repo yu kullandırmak