using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    internal class Widget : baseEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public string IconPath { get; set; }

        public bool IsOnlyNested { get; set; }

        public virtual Widget ParentWidgetID { get; set; }

        public virtual Widget ChildWidgetID { get; set; }

        public virtual AppType RelatedAppTypeID { get; set; }

        public virtual WidgetProperty WidgetProperty { get; set; }

        public virtual WidgetCodeSnippet WidgetCodeSnippet { get; set; }

    }
}
