using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    internal class WidgetPropertyMapping
    {
        WidgetPropertyMapping(EntityTypeBuilder<WidgetProperty> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(y => y.widget).WithOne(u => u.WidgetProperty).HasForeignKey<Widget>(x => x.Id);
            entityBuilder.HasOne(y => y.property).WithOne(u => u.WidgetProperty).HasForeignKey<Property>(x => x.Id);
            entityBuilder.Property(x => x.DefaultValue);
        }
    }
}
