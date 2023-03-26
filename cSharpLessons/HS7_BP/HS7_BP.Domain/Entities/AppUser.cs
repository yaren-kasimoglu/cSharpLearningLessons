using HS7_BP.Domain.Entities.Abstract;
using HS7_BP.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<Post> Likes { get; set; }
    }
}
