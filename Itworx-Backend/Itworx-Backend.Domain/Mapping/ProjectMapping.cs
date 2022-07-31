using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    public class ProjectMapping
    {
        public ProjectMapping(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title);
            entityBuilder.Property(x => x.CreationDate);
            entityBuilder.HasOne(t => t.User).WithMany(u => u.Project); // not sure of this
            entityBuilder.HasOne(t => t.AppType).WithOne(u => u.Project).HasForeignKey<AppType>(x => x.Id);
            entityBuilder.HasOne(t => t.TargetFramework).WithOne(u => u.Project).HasForeignKey<TargetFramework>(x => x.Id);
            entityBuilder.Property(x => x.GeneratedAppPath).IsRequired();
            entityBuilder.Property(x => x.Widgets).IsRequired();
            entityBuilder.Property(x => x.Description).IsRequired();
        }
    }
}
