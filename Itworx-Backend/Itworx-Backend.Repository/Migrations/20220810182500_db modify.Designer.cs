﻿// <auto-generated />
using System;
using Itworx_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220810182500_db modify")]
    partial class dbmodify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.AppType", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

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

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Widgets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnlyNested")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentPropertyIDId")
                        .HasColumnType("bigint");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentPropertyIDId")
                        .IsUnique()
                        .HasFilter("[ParentPropertyIDId] IS NOT NULL");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PropertyUnit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PropertyValue");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.TargetFramework", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

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
                        .HasColumnType("bigint");

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

                    b.Property<string>("IconPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnlyNested")
                        .HasColumnType("bit");

                    b.Property<long?>("ParentWidgetIDId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentWidgetIDId")
                        .IsUnique()
                        .HasFilter("[ParentWidgetIDId] IS NOT NULL");

                    b.ToTable("Widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CoddeSnippet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("DefaultValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedData")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifiedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WidgetProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.AppType", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Project", "Project")
                        .WithOne("AppType")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.AppType", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Widget", "Widget")
                        .WithOne("RelatedAppTypeID")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.AppType", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Widget");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Project", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.User", "User")
                        .WithMany("Project")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.PropertyUnit", "PropertyUnit")
                        .WithOne("Property")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Property", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.PropertyValue", "Value")
                        .WithOne("Property")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Property", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.WidgetProperty", "WidgetProperty")
                        .WithOne("property")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Property", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Property", "ParentPropertyID")
                        .WithOne("ChildPropertyID")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Property", "ParentPropertyIDId");

                    b.Navigation("ParentPropertyID");

                    b.Navigation("PropertyUnit");

                    b.Navigation("Value");

                    b.Navigation("WidgetProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.TargetFramework", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.Project", "Project")
                        .WithOne("TargetFramework")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.TargetFramework", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", "WidgetCodeSnippet")
                        .WithOne("TargetFramework")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.TargetFramework", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("WidgetCodeSnippet");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Unit", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.PropertyUnit", "PropertyUnit")
                        .WithOne("Unit")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Unit", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropertyUnit");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Widget", b =>
                {
                    b.HasOne("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", "WidgetCodeSnippet")
                        .WithOne("Widget")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Widget", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.WidgetProperty", "WidgetProperty")
                        .WithOne("widget")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Widget", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itworx_Backend.Domain.Entities.Widget", "ParentWidgetID")
                        .WithOne("ChildWidgetID")
                        .HasForeignKey("Itworx_Backend.Domain.Entities.Widget", "ParentWidgetIDId");

                    b.Navigation("ParentWidgetID");

                    b.Navigation("WidgetCodeSnippet");

                    b.Navigation("WidgetProperty");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Project", b =>
                {
                    b.Navigation("AppType")
                        .IsRequired();

                    b.Navigation("TargetFramework")
                        .IsRequired();
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Property", b =>
                {
                    b.Navigation("ChildPropertyID");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyUnit", b =>
                {
                    b.Navigation("Property")
                        .IsRequired();

                    b.Navigation("Unit")
                        .IsRequired();
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.PropertyValue", b =>
                {
                    b.Navigation("Property")
                        .IsRequired();
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.User", b =>
                {
                    b.Navigation("Project");
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.Widget", b =>
                {
                    b.Navigation("ChildWidgetID");

                    b.Navigation("RelatedAppTypeID")
                        .IsRequired();
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetCodeSnippet", b =>
                {
                    b.Navigation("TargetFramework")
                        .IsRequired();

                    b.Navigation("Widget")
                        .IsRequired();
                });

            modelBuilder.Entity("Itworx_Backend.Domain.Entities.WidgetProperty", b =>
                {
                    b.Navigation("property")
                        .IsRequired();

                    b.Navigation("widget")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
