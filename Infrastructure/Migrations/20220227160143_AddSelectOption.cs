using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddSelectOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldSetSelectField");

            migrationBuilder.AddColumn<int>(
                name: "FieldSetId",
                table: "SelectField",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SelectOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectOption_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalTable: "SelectField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_FieldSetId",
                table: "SelectField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectOption_SelectFieldId",
                table: "SelectOption",
                column: "SelectFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectField_FieldSet_FieldSetId",
                table: "SelectField",
                column: "FieldSetId",
                principalTable: "FieldSet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectField_FieldSet_FieldSetId",
                table: "SelectField");

            migrationBuilder.DropTable(
                name: "SelectOption");

            migrationBuilder.DropIndex(
                name: "IX_SelectField_FieldSetId",
                table: "SelectField");

            migrationBuilder.DropColumn(
                name: "FieldSetId",
                table: "SelectField");

            migrationBuilder.CreateTable(
                name: "FieldSetSelectField",
                columns: table => new
                {
                    OptionsId = table.Column<int>(type: "integer", nullable: false),
                    SelectFieldsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldSetSelectField", x => new { x.OptionsId, x.SelectFieldsId });
                    table.ForeignKey(
                        name: "FK_FieldSetSelectField_FieldSet_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "FieldSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldSetSelectField_SelectField_SelectFieldsId",
                        column: x => x.SelectFieldsId,
                        principalTable: "SelectField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldSetSelectField_SelectFieldsId",
                table: "FieldSetSelectField",
                column: "SelectFieldsId");
        }
    }
}
