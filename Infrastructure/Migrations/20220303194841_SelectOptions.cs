using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SelectOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOption_SelectField_SelectFieldId",
                table: "SelectOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectOption",
                table: "SelectOption");

            migrationBuilder.RenameTable(
                name: "SelectOption",
                newName: "SelectOptions");

            migrationBuilder.RenameIndex(
                name: "IX_SelectOption_SelectFieldId",
                table: "SelectOptions",
                newName: "IX_SelectOptions_SelectFieldId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectOptions",
                table: "SelectOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_SelectField_SelectFieldId",
                table: "SelectOptions",
                column: "SelectFieldId",
                principalTable: "SelectField",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_SelectField_SelectFieldId",
                table: "SelectOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectOptions",
                table: "SelectOptions");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "SelectOptions",
                newName: "SelectOption");

            migrationBuilder.RenameIndex(
                name: "IX_SelectOptions_SelectFieldId",
                table: "SelectOption",
                newName: "IX_SelectOption_SelectFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectOption",
                table: "SelectOption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOption_SelectField_SelectFieldId",
                table: "SelectOption",
                column: "SelectFieldId",
                principalTable: "SelectField",
                principalColumn: "Id");
        }
    }
}
