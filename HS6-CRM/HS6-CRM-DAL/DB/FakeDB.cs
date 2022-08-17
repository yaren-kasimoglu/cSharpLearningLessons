using HS6_CRM_Enttities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS6_CRM_DAL.DB
{
    public class FakeDB
    {
        private static int _userAccountId = 0; //static yapmamızın sebebi kayıt her eklendiğinde her hesabın uniqe id si olsun
        /// <summary>
        /// kullanıcı tablosu
        /// </summary>
        List<UserAccount> UserAccountList;
        public FakeDB()
        {
            //init

            UserAccountList = new List<UserAccount>();
            SeedData();
        }
        /// <summary>
        /// db ayağa kalktığında içinde test edilebilecek data oluşması için kullanılacak metod
        /// </summary>

        private void SeedData()
        {
            UserAccountList.Add(new UserAccount() { UserAccountId = NextUserAccountId(), UserName = "Yaren", Password = "1234", FullName = "Yaren Kasımoğlu", RecordDate = DateTime.Now, ModifiedDate = DateTime.Now });
        }

        public List<UserAccount> UserAccount
        {
            get { return UserAccountList; }
        }
        /// <summary>
        /// kullanıcı tablosu id sini yönetsin
        /// </summary>
        /// <returns></returns>
        public int NextUserAccountId()
        {
            return _userAccountId + 1;
        }
    }
}
