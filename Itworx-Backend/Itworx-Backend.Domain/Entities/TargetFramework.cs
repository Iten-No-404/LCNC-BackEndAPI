using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class TargetFramework : baseEntity
    {
        public string FrameworkName { get; set; }
        public virtual Project? Project { get; set; }

        public virtual WidgetCodeSnippet? WidgetCodeSnippet { get; set; }

    }
}
