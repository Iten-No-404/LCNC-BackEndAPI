using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class Project : baseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GeneratedAppPath { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual AppType AppType { get; set; }

        public virtual TargetFramework TargetFramework { get; set; }

        public virtual User User { get; set; }

        public virtual string Widgets { get; set; }

    }
}
