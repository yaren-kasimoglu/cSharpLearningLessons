﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS7_BP.Domain.Entities.Abstract
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
