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
    public class PropertyValueMapping : IEntityTypeConfiguration<PropertyValue>
    {
        public void Configure(EntityTypeBuilder<PropertyValue> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Value);
            entityBuilder.Property(x=>x.IsDefault);
            entityBuilder.HasOne(x => x.Property).WithOne(y => y.PropertyValue).HasForeignKey<PropertyValue>(z => z.Id);
        }
    }
}
