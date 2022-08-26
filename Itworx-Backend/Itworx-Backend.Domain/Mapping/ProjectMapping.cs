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
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure (EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).IsRequired();
            entityBuilder.Property(x => x.CreationDate).IsRequired();
            entityBuilder.HasOne(t => t.User).WithMany(u => u.Project); // not sure of this
            entityBuilder.HasOne(t => t.AppType).WithMany(u => u.ProjectList);
            entityBuilder.HasOne(t => t.TargetFramework).WithMany(u => u.ProjectList);
            entityBuilder.Property(x => x.GeneratedAppPath).IsRequired();
            entityBuilder.Property(x => x.Widgets).IsRequired();
            entityBuilder.Property(x => x.Description).IsRequired();
        }
    }
}
