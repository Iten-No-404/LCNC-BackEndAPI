using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class Widget : baseEntity
    {
        public string type { get; set; }
        public string text { get; set; }
        public string description { get; set; }
        public string IconPath { get; set; }

        public bool IsOnlyNested { get; set; }

        public int parentID { get; set; }
        public virtual Widget? ParentWidget { get; set; }

        public int childID { get; set; }
        public virtual Widget? ChildWidget { get; set; }

        public int AppTypeID { get; set; }
        public virtual AppType? RelatedAppType { get; set; }

        public int PropertyID { get; set; }
        public virtual WidgetProperty? WidgetProperty { get; set; }

        public int CodeSnippetID { get; set; }
        public virtual WidgetCodeSnippet? WidgetCodeSnippet { get; set; }

    }
}
