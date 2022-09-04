using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class userToken : baseEntity
    {
        public string? token { get; set; } = "";
        public string? uuid { get; set; } = "";

        public int userid { get; set; }
        public virtual User? user { get; set; }

    }
}
