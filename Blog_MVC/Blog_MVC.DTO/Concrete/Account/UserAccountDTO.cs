using Blog_MVC.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.DTO.Concrete
{
    public class UserAccountDTO:BaseDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
