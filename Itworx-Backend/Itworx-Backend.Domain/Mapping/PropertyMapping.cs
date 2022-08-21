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
    public class PropertyMapping : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x=>x.PropertyName).IsRequired();
            entityBuilder.Property(x=>x.Description).IsRequired();
            entityBuilder.Property(x=>x.IsOnlyNested);
            entityBuilder.HasOne(u => u.ParentProperty).WithOne(y => y.ChildProperty);
        }
    }
}
