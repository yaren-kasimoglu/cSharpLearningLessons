using HS7_BP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Application.Models.DTOs.PostDTOs
{
    public class PostCreateDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AuthorID { get; set; }
        public string Summary { get; set; }
        public string MinRead { get; set; }
        public ushort ViewCount { get; set; }
    }
}
