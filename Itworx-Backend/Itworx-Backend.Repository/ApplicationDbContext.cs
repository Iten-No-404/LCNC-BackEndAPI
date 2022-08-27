using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMapping());
            builder.ApplyConfiguration(new ProjectMapping());
            
            builder.ApplyConfiguration(new AppTypeMapping());
            builder.ApplyConfiguration(new TargetFrameworkMapping());
            
            builder.ApplyConfiguration(new WidgetMapping());
            builder.ApplyConfiguration(new WidgetPropertyMapping());
            builder.ApplyConfiguration(new WidgetCodeSnippetMapping());
            
            builder.ApplyConfiguration(new PropertyMapping());
            builder.ApplyConfiguration(new UnitMapping());
            builder.ApplyConfiguration(new PropertyUnitMapping());
            builder.ApplyConfiguration(new PropertyValueMapping());
            builder.ApplyConfiguration(new ImageFileMapping());


            base.OnModelCreating(builder);
        }
    }
}
