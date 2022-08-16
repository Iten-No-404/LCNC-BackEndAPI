using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    public partial class AddFrameworkid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoddeSnippet",
                table: "WidgetCodeSnippet",
                newName: "CodeSnippet");

            migrationBuilder.AddColumn<int>(
                name: "TargetFramworkId",
                table: "WidgetCodeSnippet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetFramworkId",
                table: "WidgetCodeSnippet");

            migrationBuilder.RenameColumn(
                name: "CodeSnippet",
                table: "WidgetCodeSnippet",
                newName: "CoddeSnippet");
        }
    }
}
