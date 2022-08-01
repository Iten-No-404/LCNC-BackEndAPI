﻿using Itworx_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Domain.Mapping
{
    public class WidgetMapping : IEntityTypeConfiguration<Widget>
    {
        public void Configure (EntityTypeBuilder<Widget> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x=>x.title).IsRequired();
            entityBuilder.Property(x=>x.description).IsRequired();
            entityBuilder.HasOne(u => u.ParentWidgetID).WithOne(y => y.ChildWidgetID);
            entityBuilder.Property(x=>x.IconPath).IsRequired();
            entityBuilder.Property(x => x.IsOnlyNested);
            entityBuilder.HasOne(u => u.RelatedAppTypeID).WithOne(y => y.Widget).HasForeignKey<AppType>(x => x.Id);
        }
    }
}
