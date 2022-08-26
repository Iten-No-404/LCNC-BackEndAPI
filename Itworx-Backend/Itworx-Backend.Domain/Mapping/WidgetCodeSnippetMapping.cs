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
    public class WidgetCodeSnippetMapping : IEntityTypeConfiguration<WidgetCodeSnippet>
    {
        public void Configure(EntityTypeBuilder<WidgetCodeSnippet> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasOne(y => y.Widget).WithOne(u => u.WidgetCodeSnippet).HasForeignKey<WidgetCodeSnippet>(x => x.Id);
            entityBuilder.HasOne(y => y.TargetFramework).WithMany(u => u.WidgetCodeSnippet);
            entityBuilder.Property(x => x.code1);
            entityBuilder.Property(x => x.code2);

        }
    }
}
