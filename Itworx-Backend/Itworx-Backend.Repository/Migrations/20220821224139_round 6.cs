using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    public partial class round6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnlyNested = table.Column<bool>(type: "bit", nullable: false),
                    parentID = table.Column<int>(type: "int", nullable: false),
                    ParentPropertyId = table.Column<long>(type: "bigint", nullable: true),
                    childID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    ValueID = table.Column<int>(type: "int", nullable: false),
                    widgetID = table.Column<int>(type: "int", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Property_Property_ParentPropertyId",
                        column: x => x.ParentPropertyId,
                        principalTable: "Property",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TargetFramework",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FrameworkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetFramework", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
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
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnlyNested = table.Column<bool>(type: "bit", nullable: false),
                    parentID = table.Column<int>(type: "int", nullable: false),
                    ParentWidgetId = table.Column<long>(type: "bigint", nullable: true),
                    childID = table.Column<int>(type: "int", nullable: false),
                    AppTypeID = table.Column<int>(type: "int", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    CodeSnippetID = table.Column<int>(type: "int", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_AppType_Id",
                        column: x => x.Id,
                        principalTable: "AppType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Widget_Widget_ParentWidgetId",
                        column: x => x.ParentWidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PropertyValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyValue_Property_Id",
                        column: x => x.Id,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyUnit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    unitID = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyUnit_Property_Id",
                        column: x => x.Id,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyUnit_Unit_Id",
                        column: x => x.Id,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratedAppPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppTypeId = table.Column<int>(type: "int", nullable: false),
                    targetFrameworkId = table.Column<int>(type: "int", nullable: false),
                    user_Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Widgets = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_AppType_Id",
                        column: x => x.Id,
                        principalTable: "AppType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_TargetFramework_Id",
                        column: x => x.Id,
                        principalTable: "TargetFramework",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WidgetCodeSnippet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TargetFramworkId = table.Column<int>(type: "int", nullable: false),
                    CodeSnippet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetCodeSnippet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetCodeSnippet_TargetFramework_Id",
                        column: x => x.Id,
                        principalTable: "TargetFramework",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidgetCodeSnippet_Widget_Id",
                        column: x => x.Id,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WidgetProperty",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    widgetId = table.Column<int>(type: "int", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyID = table.Column<int>(type: "int", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetProperty_Property_Id",
                        column: x => x.Id,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidgetProperty_Widget_Id",
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
                name: "IX_Property_ParentPropertyId",
                table: "Property",
                column: "ParentPropertyId",
                unique: true,
                filter: "[ParentPropertyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_ParentWidgetId",
                table: "Widget",
                column: "ParentWidgetId",
                unique: true,
                filter: "[ParentWidgetId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "PropertyUnit");

            migrationBuilder.DropTable(
                name: "PropertyValue");

            migrationBuilder.DropTable(
                name: "WidgetCodeSnippet");

            migrationBuilder.DropTable(
                name: "WidgetProperty");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "TargetFramework");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Widget");

            migrationBuilder.DropTable(
                name: "AppType");
        }
    }
}
