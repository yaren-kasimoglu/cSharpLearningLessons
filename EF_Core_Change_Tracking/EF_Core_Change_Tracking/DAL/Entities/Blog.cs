﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Change_Tracking.DAL.Entities
{
    public class Blog
    {
        public Blog()
        {
            this.Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
