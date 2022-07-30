using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    internal class UserMapping
    {
        public UserMapping(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x=>x.IsEmailConfirmed);
            entityBuilder.Property(x=>x.IsActive);
            entityBuilder.Property(x => x.FullName).IsRequired();
            entityBuilder.Property(x => x.SubscriptionDate).IsRequired();
            entityBuilder.Property(x => x.Password).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired();
            entityBuilder.Property(x => x.PhoneNo).IsRequired();
        }
    }
}
