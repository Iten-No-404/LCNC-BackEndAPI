﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class PropertyValue : baseEntity
    {
        public string Value { get; set; }

        public int propertyID { get; set; }
        public virtual Property? Property { get; set; }

        public bool IsDefault { get; set; }
    }
}
