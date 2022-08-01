using Itworx_Backend.Domain.Entities;
using Itworx_Backend.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itworx_Backend.Persistence
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

            base.OnModelCreating(builder);
        }
      /*  public DbSet<AppType> AppType { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Property> Property { get; set; }

        public DbSet<PropertyUnit> PropertyUnit { get; set; }

        public DbSet<PropertyValue> PropertyValue { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<TargetFramework> TargetFrameworks { get; set; }

        public DbSet<Widget> Widgets { get; set; }

        public DbSet<WidgetCodeSnippet> WidgetCodeSnippets { get; set; }

        public DbSet<WidgetProperty> WidgetProperty { get; set; }
      */
    }
}
