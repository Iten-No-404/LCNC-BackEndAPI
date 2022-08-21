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

        public int parentID { get; set; }
        public virtual Property? ParentProperty { get; set; }


        public int childID { get; set; }
        public virtual Property? ChildProperty { get; set; }

        public int UnitID { get; set; }
        public virtual PropertyUnit? PropertyUnit { get; set; }

        public int ValueID { get; set; }
        public virtual PropertyValue? PropertyValue { get; set; }

        public int widgetID { get; set; }
        public virtual WidgetProperty? WidgetProperty { get; set; }
    }
}
