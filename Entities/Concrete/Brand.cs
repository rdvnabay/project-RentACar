﻿using Core.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
