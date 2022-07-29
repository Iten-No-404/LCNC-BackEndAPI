using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    internal class PropertyUnit : baseEntity
    {
        public virtual Property Property { get; set; }

        public virtual Unit Unit { get; set; }

        public bool IsDefault { get; set; }

    }
}
