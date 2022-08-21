using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class PropertyUnit : baseEntity
    {
        public int propertyID { get; set; }
        public virtual Property? Property { get; set; }

        public int unitID { get; set; }
        public virtual Unit? Unit { get; set; }

        public bool IsDefault { get; set; }

    }
}
