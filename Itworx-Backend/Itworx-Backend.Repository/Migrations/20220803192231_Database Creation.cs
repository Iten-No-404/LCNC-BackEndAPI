using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidgetCodeSnippet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoddeSnippet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetCodeSnippet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WidgetProperty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_PropertyUnit_Id",
                        column: x => x.Id,
                        principalTable: "PropertyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedAppPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Widgets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnlyNested = table.Column<bool>(type: "bit", nullable: false),
                    ParentPropertyIDId = table.Column<long>(type: "bigint", nullable: true),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Property_ParentPropertyIDId",
                        column: x => x.ParentPropertyIDId,
                        principalTable: "Property",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Property_PropertyUnit_Id",
                        column: x => x.Id,
                        principalTable: "PropertyUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_PropertyValue_Id",
                        column: x => x.Id,
                        principalTable: "PropertyValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_WidgetProperty_Id",
                        column: x => x.Id,
                        principalTable: "WidgetProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnlyNested = table.Column<bool>(type: "bit", nullable: false),
                    ParentWidgetIDId = table.Column<long>(type: "bigint", nullable: true),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_Widget_ParentWidgetIDId",
                        column: x => x.ParentWidgetIDId,
                        principalTable: "Widget",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Widget_WidgetCodeSnippet_Id",
                        column: x => x.Id,
                        principalTable: "WidgetCodeSnippet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Widget_WidgetProperty_Id",
                        column: x => x.Id,
                        principalTable: "WidgetProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetFramework",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    FrameworkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetFramework", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TargetFramework_Project_Id",
                        column: x => x.Id,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetFramework_WidgetCodeSnippet_Id",
                        column: x => x.Id,
                        principalTable: "WidgetCodeSnippet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppType_Project_Id",
                        column: x => x.Id,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppType_Widget_Id",
                        column: x => x.Id,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ParentPropertyIDId",
                table: "Property",
                column: "ParentPropertyIDId",
                unique: true,
                filter: "[ParentPropertyIDId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_ParentWidgetIDId",
                table: "Widget",
                column: "ParentWidgetIDId",
                unique: true,
                filter: "[ParentWidgetIDId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppType");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "TargetFramework");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Widget");

            migrationBuilder.DropTable(
                name: "PropertyValue");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "PropertyUnit");

            migrationBuilder.DropTable(
                name: "WidgetCodeSnippet");

            migrationBuilder.DropTable(
                name: "WidgetProperty");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
