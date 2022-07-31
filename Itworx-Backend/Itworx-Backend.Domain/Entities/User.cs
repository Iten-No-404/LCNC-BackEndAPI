using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Entities
{
    public class User : baseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public int PhoneNo { get; set; }

        public string Password { get; set; }
        
        public DateTime SubscriptionDate { get; set; }

        public bool IsEmailConfirmed  { get; set; }

        public bool IsActive { get; set; }

        public virtual IList<Project>? Project { get; set; }
    }
}
