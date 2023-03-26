using HS7_BP.Domain.Entities.Abstract;
using HS7_BP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Entities
{
    public class Author : IBaseEntity, IEntity<Guid>
    {
        public Author()
        {

        }
        public string FullName { get; set; }
        public string UserID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
        public Guid Id { get; set; }


        public AppUser User { get; set; }
        List<Post> Posts { get; set; }
    }
}
