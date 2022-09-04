using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Itworx_Backend.Repository.Migrations
{
    public partial class AddUserTokensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tokenId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "userToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    addedData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userToken_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userToken_userid",
                table: "userToken",
                column: "userid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userToken");

            migrationBuilder.DropColumn(
                name: "tokenId",
                table: "User");
        }
    }
}
