using HS7_BP.Domain.Entities.Abstract;
using HS7_BP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Entities
{
    public class Post : IBaseEntity, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public string Summary { get; set; }
        public string MinRead { get; set; }
        public int ViewCount { get; set; }
        public string Comment { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }

      public virtual List<Category> Categories { get; set; }
      public virtual List<AppUser> Likes { get; set; }
      public virtual List<AppUser> Follows { get; set; }



    }
}
