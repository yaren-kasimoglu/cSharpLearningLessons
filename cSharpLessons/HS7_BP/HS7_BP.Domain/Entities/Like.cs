
using HS7_BP.Domain.Entities.Abstract;
using HS7_BP.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Entities
{
    [PrimaryKey(nameof(PostId), nameof(UserId))]
    public class Like : IBaseEntity
    {
        public Guid PostId { get; set; }

        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }

        public Post Post { get; set; }
        public AppUser User { get; set; }

    }
}
