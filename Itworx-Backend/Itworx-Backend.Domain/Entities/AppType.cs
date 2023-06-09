﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class AppType : baseEntity 
    {
        public string type { get; set; }
        public virtual IList<Project>? ProjectList { get; set; }

        public virtual IList<Widget>? Widget { get; set; }
    }
}
