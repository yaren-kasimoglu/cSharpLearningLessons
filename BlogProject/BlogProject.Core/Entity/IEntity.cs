﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Entity
{
    public interface IEntity<T>
    {
        T  ID { get; set; }
    }
}
