﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.Entities.Concrete
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
