using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    internal class Property : baseEntity
    {
        public string PropertyName { get; set; }

        public virtual Property ParentPropertyID { get; set; }

        public string Description { get; set; }

        public bool IsOnlyNested { get; set; }

    }
}
