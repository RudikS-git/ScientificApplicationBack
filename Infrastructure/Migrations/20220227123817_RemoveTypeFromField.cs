using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveTypeFromField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldSet_FieldTypes_FieldTypeId",
                table: "FieldSet");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_FieldTypes_FieldTypeId",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectField_FieldTypes_FieldTypeId",
                table: "SelectField");

            migrationBuilder.DropIndex(
                name: "IX_SelectField_FieldTypeId",
                table: "SelectField");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_FieldTypeId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_FieldSet_FieldTypeId",
                table: "FieldSet");

            migrationBuilder.DropColumn(
                name: "FieldTypeId",
                table: "SelectField");

            migrationBuilder.DropColumn(
                name: "FieldTypeId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "FieldTypeId",
                table: "FieldSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldTypeId",
                table: "SelectField",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldTypeId",
                table: "InputFields",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldTypeId",
                table: "FieldSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_FieldTypeId",
                table: "SelectField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_FieldTypeId",
                table: "InputFields",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_FieldTypeId",
                table: "FieldSet",
                column: "FieldTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSet_FieldTypes_FieldTypeId",
                table: "FieldSet",
                column: "FieldTypeId",
                principalTable: "FieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_FieldTypes_FieldTypeId",
                table: "InputFields",
                column: "FieldTypeId",
                principalTable: "FieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectField_FieldTypes_FieldTypeId",
                table: "SelectField",
                column: "FieldTypeId",
                principalTable: "FieldTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
