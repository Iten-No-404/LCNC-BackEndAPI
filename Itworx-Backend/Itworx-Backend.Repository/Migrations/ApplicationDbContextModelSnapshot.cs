﻿// <auto-generated />
using System;
using Itworx_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.AppType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppType");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Project", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("AppTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneratedAppPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Widgets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("targetFrameworkId")
                        .HasColumnType("int");

                    b.Property<int>("user_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnlyNested")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentPropertyId")
                        .HasColumnType("bigint");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<int>("ValueID")
                        .HasColumnType("int");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<int>("childID")
                        .HasColumnType("int");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("parentID")
                        .HasColumnType("int");

                    b.Property<int>("widgetID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentPropertyId")
                        .IsUnique()
                        .HasFilter("[ParentPropertyId] IS NOT NULL");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyUnit", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.Property<int>("unitID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PropertyUnit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyValue", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PropertyValue");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.TargetFramework", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FrameworkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TargetFramework");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Unit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Widget", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("AppTypeID")
                        .HasColumnType("int");

                    b.Property<int>("CodeSnippetID")
                        .HasColumnType("int");

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnlyNested")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentWidgetId")
                        .HasColumnType("bigint");

                    b.Property<int>("PropertyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<int>("childID")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("parentID")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentWidgetId")
                        .IsUnique()
                        .HasFilter("[ParentWidgetId] IS NOT NULL");

                    b.ToTable("Widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("CodeSnippet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TargetFramworkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WidgetCodeSnippet");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetProperty", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.Property<int>("widgetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WidgetProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Project", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.AppType", "AppType")
                        .WithOne("Project")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Project", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.TargetFramework", "TargetFramework")
                        .WithOne("Project")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Project", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.User", "User")
                        .WithMany("Project")
                        .HasForeignKey("UserId");

                    b.Navigation("AppType");

                    b.Navigation("TargetFramework");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Property", "ParentProperty")
                        .WithOne("ChildProperty")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Property", "ParentPropertyId");

                    b.Navigation("ParentProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyUnit", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Property", "Property")
                        .WithOne("PropertyUnit")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.PropertyUnit", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Unit", "Unit")
                        .WithOne("PropertyUnit")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.PropertyUnit", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyValue", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Property", "Property")
                        .WithOne("PropertyValue")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.PropertyValue", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Widget", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.AppType", "RelatedAppType")
                        .WithOne("Widget")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Widget", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Widget", "ParentWidget")
                        .WithOne("ChildWidget")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Widget", "ParentWidgetId");

                    b.Navigation("ParentWidget");

                    b.Navigation("RelatedAppType");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.TargetFramework", "TargetFramework")
                        .WithOne("WidgetCodeSnippet")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Widget", "Widget")
                        .WithOne("WidgetCodeSnippet")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TargetFramework");

                    b.Navigation("Widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetProperty", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Property", "property")
                        .WithOne("WidgetProperty")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.WidgetProperty", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Widget", "widget")
                        .WithOne("WidgetProperty")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.WidgetProperty", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("property");

                    b.Navigation("widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.AppType", b =>
                {
                    b.Navigation("Project");

                    b.Navigation("Widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.Navigation("ChildProperty");

                    b.Navigation("PropertyUnit");

                    b.Navigation("PropertyValue");

                    b.Navigation("WidgetProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.TargetFramework", b =>
                {
                    b.Navigation("Project");

                    b.Navigation("WidgetCodeSnippet");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Unit", b =>
                {
                    b.Navigation("PropertyUnit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.User", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Widget", b =>
                {
                    b.Navigation("ChildWidget");

                    b.Navigation("WidgetCodeSnippet");

                    b.Navigation("WidgetProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
