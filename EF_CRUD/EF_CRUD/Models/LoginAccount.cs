using System;
using System.Collections.Generic;

namespace EF_CRUD.Models
{
    public partial class LoginAccount
    {
        public string UserName { get; set; } = null!;
        public string Pass { get; set; } = null!;
    }
}
