using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    public class PropertyMapping
    {
        public PropertyMapping(EntityTypeBuilder<Property> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x=>x.PropertyName).IsRequired();
            entityBuilder.Property(x=>x.Description).IsRequired();
            entityBuilder.Property(x=>x.IsOnlyNested);
            entityBuilder.HasOne(u => u.ParentPropertyID).WithOne(y => y.ChildPropertyID).HasForeignKey<Property>(x => x.Id);
        }
    }
}
