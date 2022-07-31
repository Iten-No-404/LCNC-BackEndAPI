using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class Unit : baseEntity
    {
        public string UnitName { get; set; }

        public bool IsDefault { get; set; }

        public PropertyUnit PropertyUnit { get; set; }
    }
}
