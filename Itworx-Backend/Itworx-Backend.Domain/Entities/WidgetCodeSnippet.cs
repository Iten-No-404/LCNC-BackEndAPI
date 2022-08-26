using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class WidgetCodeSnippet : baseEntity
    {

        public virtual Widget? Widget { get; set; }
        
        public virtual TargetFramework? TargetFramework { get; set; }

        public int TargetFramworkId { get; set; }
        public int widgetId { get; set; }
        public string code1 { get; set; }
        public string code2 { get; set; }

    }
}
