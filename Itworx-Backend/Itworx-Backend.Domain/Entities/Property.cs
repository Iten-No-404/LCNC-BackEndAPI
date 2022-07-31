using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class Property : baseEntity
    {
        public string PropertyName { get; set; }

        public string Description { get; set; }

        public bool IsOnlyNested { get; set; }


        public virtual Property ParentPropertyID { get; set; }

        public virtual Property ChildPropertyID { get; set; }

        public virtual PropertyUnit PropertyUnit { get; set; }

        public virtual PropertyValue Value { get; set; }

        public virtual WidgetProperty WidgetProperty { get; set; }
    }
}
