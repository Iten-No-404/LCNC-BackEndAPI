using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class WidgetProperty : baseEntity
    {
        public int widgetId { get; set; }
        public virtual Widget? widget { get; set; }

        public string DefaultValue { get; set; }

        public int propertyID { get; set; }
        public virtual Property? property { get; set; }
    }
}
