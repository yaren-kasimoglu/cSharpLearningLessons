﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakDukkani_MaratonEFCore.DAL.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
