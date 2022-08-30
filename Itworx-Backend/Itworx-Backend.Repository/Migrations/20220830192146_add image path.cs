using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    public partial class addimagepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ImageFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ImageFile");
        }
    }
}
