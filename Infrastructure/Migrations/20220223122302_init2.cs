using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputFields_InputDate_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputFields_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputFields_InputNumber_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropForeignKey(
                name: "FK_InputFields_InputFields_InputNumberPhone_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputDate_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputNumber_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropIndex(
                name: "IX_InputFields_InputNumberPhone_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputDate_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputFieldId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputNumberPhone_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "InputNumber_InputFieldId",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "Max",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "MaxDateTime",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "MinDateTime",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "MinLength",
                table: "InputFields");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "InputFields");

            migrationBuilder.CreateTable(
                name: "InputDateField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MinDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDateField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputDateField_InputFields_Id",
                        column: x => x.Id,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputDateField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputNumberField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Min = table.Column<int>(type: "integer", nullable: false),
                    Max = table.Column<int>(type: "integer", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberField_InputFields_Id",
                        column: x => x.Id,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputNumberField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputNumberPhoneField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberPhoneField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_InputFields_Id",
                        column: x => x.Id,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputTextField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    MinLength = table.Column<int>(type: "integer", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTextField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputTextField_InputFields_Id",
                        column: x => x.Id,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputTextField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_InputFieldId",
                table: "InputDateField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_InputFieldId",
                table: "InputNumberField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_InputFieldId",
                table: "InputNumberPhoneField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_InputFieldId",
                table: "InputTextField",
                column: "InputFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputDateField");

            migrationBuilder.DropTable(
                name: "InputNumberField");

            migrationBuilder.DropTable(
                name: "InputNumberPhoneField");

            migrationBuilder.DropTable(
                name: "InputTextField");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "InputFields",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InputDate_InputFieldId",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputFieldId",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputNumberPhone_InputFieldId",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InputNumber_InputFieldId",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaxDateTime",
                table: "InputFields",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MinDateTime",
                table: "InputFields",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinLength",
                table: "InputFields",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "InputFields",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputDate_InputFieldId",
                table: "InputFields",
                column: "InputDate_InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputFieldId",
                table: "InputFields",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputNumber_InputFieldId",
                table: "InputFields",
                column: "InputNumber_InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputNumberPhone_InputFieldId",
                table: "InputFields",
                column: "InputNumberPhone_InputFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputFields_InputDate_InputFieldId",
                table: "InputFields",
                column: "InputDate_InputFieldId",
                principalTable: "InputFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputFields_InputFieldId",
                table: "InputFields",
                column: "InputFieldId",
                principalTable: "InputFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputFields_InputNumber_InputFieldId",
                table: "InputFields",
                column: "InputNumber_InputFieldId",
                principalTable: "InputFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputFields_InputFields_InputNumberPhone_InputFieldId",
                table: "InputFields",
                column: "InputNumberPhone_InputFieldId",
                principalTable: "InputFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
