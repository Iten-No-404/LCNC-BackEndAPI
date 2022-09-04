using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    public class userTokenMapping : IEntityTypeConfiguration<userToken>
    {
        public void Configure(EntityTypeBuilder<userToken> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.uuid);
            entityBuilder.HasOne(x => x.user).WithOne(u=>u.UserToken).HasForeignKey<userToken>(x => x.userid);
        }
    }
}
