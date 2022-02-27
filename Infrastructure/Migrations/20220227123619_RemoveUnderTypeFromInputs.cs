using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveUnderTypeFromInputs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_ApplicationGroup_ApplicationGroupId",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputUnderType_InputUnderTypeId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_ApplicationGroupId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputUnderTypeId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputUnderTypeId",
                table: "InputFields");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InputUnderTypeId",
                table: "InputFields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_ApplicationGroupId",
                table: "InputFields",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputUnderTypeId",
                table: "InputFields",
                column: "InputUnderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_ApplicationGroup_ApplicationGroupId",
                table: "InputFields",
                column: "ApplicationGroupId",
                principalTable: "ApplicationGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputUnderType_InputUnderTypeId",
                table: "InputFields",
                column: "InputUnderTypeId",
                principalTable: "InputUnderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
