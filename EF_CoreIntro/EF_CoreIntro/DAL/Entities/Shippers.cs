﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CoreIntro.DAL.Entities
{
    public class Shippers
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string? Phone { get; set; }
    }
}
