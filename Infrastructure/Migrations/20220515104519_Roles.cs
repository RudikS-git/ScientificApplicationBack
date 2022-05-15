using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "Role",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                schema: "Identity",
                table: "Role",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_AspNetUsers_UserId",
                schema: "Identity",
                table: "Role",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_AspNetUsers_UserId",
                schema: "Identity",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId",
                schema: "Identity",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Identity",
                table: "Role");
        }
    }
}
