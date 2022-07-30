using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    internal class PropertyUnitMapping
    {
        PropertyUnitMapping(EntityTypeBuilder<PropertyUnit> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(x => x.Property).WithOne(u => u.PropertyUnit).HasForeignKey<Property>(y => y.Id);
            entityBuilder.HasOne(x => x.Unit).WithOne(u => u.PropertyUnit).HasForeignKey<Unit>(y => y.Id);
            entityBuilder.Property(x => x.IsDefault);
        }
    }
}
