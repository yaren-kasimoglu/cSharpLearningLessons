using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.Entities.Concrete
{
    public class UserAccount : IdentityUser<int>
    {
        public UserAccount()
        {

        }
    }
}
