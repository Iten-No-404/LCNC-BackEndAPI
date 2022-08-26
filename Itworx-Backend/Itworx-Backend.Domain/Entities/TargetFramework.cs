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
        public virtual IList<Project>? ProjectList { get; set; }

        public virtual IList<WidgetCodeSnippet>? WidgetCodeSnippet { get; set; }

    }
}
