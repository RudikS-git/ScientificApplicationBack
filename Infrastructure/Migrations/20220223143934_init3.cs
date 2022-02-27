using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_InputFields_InputFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_SelectField_SelectFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_Submissions_SubmissionId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_WorkEntityField_WorkEntityFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropTable(
                name: "WorkEntityField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FieldSubmission",
                table: "FieldSubmission");

            migrationBuilder.DropIndex(
                name: "IX_FieldSubmission_InputFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropIndex(
                name: "IX_FieldSubmission_WorkEntityFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FieldSubmission");

            migrationBuilder.DropColumn(
                name: "InputFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FieldSubmission");

            migrationBuilder.DropColumn(
                name: "WorkEntityFieldId",
                table: "FieldSubmission");

            migrationBuilder.RenameTable(
                name: "FieldSubmission",
                newName: "SelectSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_FieldSubmission_SubmissionId",
                table: "SelectSubmission",
                newName: "IX_SelectSubmission_SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_FieldSubmission_SelectFieldId",
                table: "SelectSubmission",
                newName: "IX_SelectSubmission_SelectFieldId");

            migrationBuilder.AddColumn<int>(
                name: "EntityFieldId",
                table: "InputTextField",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityFieldId",
                table: "InputNumberPhoneField",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityFieldId",
                table: "InputNumberField",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityFieldId",
                table: "InputDateField",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SelectFieldId",
                table: "SelectSubmission",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SelectSubmission",
                table: "SelectSubmission",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EntityField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectSubmissionId = table.Column<int>(type: "integer", nullable: true),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    FieldTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityField_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityField_SelectSubmission_SelectSubmissionId",
                        column: x => x.SelectSubmissionId,
                        principalTable: "SelectSubmission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InputSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    SubmissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputSubmission_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputSubmission_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldSelectField",
                columns: table => new
                {
                    OptionsId = table.Column<int>(type: "integer", nullable: false),
                    SelectFieldsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldSelectField", x => new { x.OptionsId, x.SelectFieldsId });
                    table.ForeignKey(
                        name: "FK_EntityFieldSelectField_EntityField_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntityFieldSelectField_SelectField_SelectFieldsId",
                        column: x => x.SelectFieldsId,
                        principalTable: "SelectField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_EntityFieldId",
                table: "InputTextField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_EntityFieldId",
                table: "InputNumberPhoneField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_EntityFieldId",
                table: "InputNumberField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_EntityFieldId",
                table: "InputDateField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_ApplicationGroupId",
                table: "EntityField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_FieldTypeId",
                table: "EntityField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_SelectSubmissionId",
                table: "EntityField",
                column: "SelectSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldSelectField_SelectFieldsId",
                table: "EntityFieldSelectField",
                column: "SelectFieldsId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_InputFieldId",
                table: "InputSubmission",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_SubmissionId",
                table: "InputSubmission",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputDateField_EntityField_EntityFieldId",
                table: "InputDateField",
                column: "EntityFieldId",
                principalTable: "EntityField",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputNumberField_EntityField_EntityFieldId",
                table: "InputNumberField",
                column: "EntityFieldId",
                principalTable: "EntityField",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputNumberPhoneField_EntityField_EntityFieldId",
                table: "InputNumberPhoneField",
                column: "EntityFieldId",
                principalTable: "EntityField",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputTextField_EntityField_EntityFieldId",
                table: "InputTextField",
                column: "EntityFieldId",
                principalTable: "EntityField",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectSubmission_SelectField_SelectFieldId",
                table: "SelectSubmission",
                column: "SelectFieldId",
                principalTable: "SelectField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectSubmission_Submissions_SubmissionId",
                table: "SelectSubmission",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputDateField_EntityField_EntityFieldId",
                table: "InputDateField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputNumberField_EntityField_EntityFieldId",
                table: "InputNumberField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputNumberPhoneField_EntityField_EntityFieldId",
                table: "InputNumberPhoneField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputTextField_EntityField_EntityFieldId",
                table: "InputTextField");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSubmission_SelectField_SelectFieldId",
                table: "SelectSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSubmission_Submissions_SubmissionId",
                table: "SelectSubmission");

            migrationBuilder.DropTable(
                name: "EntityFieldSelectField");

            migrationBuilder.DropTable(
                name: "InputSubmission");

            migrationBuilder.DropTable(
                name: "EntityField");

            migrationBuilder.DropIndex(
                name: "IX_InputTextField_EntityFieldId",
                table: "InputTextField");

            migrationBuilder.DropIndex(
                name: "IX_InputNumberPhoneField_EntityFieldId",
                table: "InputNumberPhoneField");

            migrationBuilder.DropIndex(
                name: "IX_InputNumberField_EntityFieldId",
                table: "InputNumberField");

            migrationBuilder.DropIndex(
                name: "IX_InputDateField_EntityFieldId",
                table: "InputDateField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SelectSubmission",
                table: "SelectSubmission");

            migrationBuilder.DropColumn(
                name: "EntityFieldId",
                table: "InputTextField");

            migrationBuilder.DropColumn(
                name: "EntityFieldId",
                table: "InputNumberPhoneField");

            migrationBuilder.DropColumn(
                name: "EntityFieldId",
                table: "InputNumberField");

            migrationBuilder.DropColumn(
                name: "EntityFieldId",
                table: "InputDateField");

            migrationBuilder.RenameTable(
                name: "SelectSubmission",
                newName: "FieldSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_SelectSubmission_SubmissionId",
                table: "FieldSubmission",
                newName: "IX_FieldSubmission_SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectSubmission_SelectFieldId",
                table: "FieldSubmission",
                newName: "IX_FieldSubmission_SelectFieldId");

            migrationBuilder.AlterColumn<int>(
                name: "SelectFieldId",
                table: "FieldSubmission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FieldSubmission",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InputFieldId",
                table: "FieldSubmission",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FieldSubmission",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkEntityFieldId",
                table: "FieldSubmission",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FieldSubmission",
                table: "FieldSubmission",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WorkEntityField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FieldSubmissionId = table.Column<int>(type: "integer", nullable: false),
                    FieldTypeId = table.Column<int>(type: "integer", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: true),
                    SelectSubmissionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEntityField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkEntityField_FieldSubmission_FieldSubmissionId",
                        column: x => x.FieldSubmissionId,
                        principalTable: "FieldSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEntityField_FieldSubmission_SelectSubmissionId",
                        column: x => x.SelectSubmissionId,
                        principalTable: "FieldSubmission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkEntityField_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEntityField_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalTable: "SelectField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_InputFieldId",
                table: "FieldSubmission",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_WorkEntityFieldId",
                table: "FieldSubmission",
                column: "WorkEntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEntityField_FieldSubmissionId",
                table: "WorkEntityField",
                column: "FieldSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEntityField_FieldTypeId",
                table: "WorkEntityField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEntityField_SelectFieldId",
                table: "WorkEntityField",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEntityField_SelectSubmissionId",
                table: "WorkEntityField",
                column: "SelectSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSubmission_InputFields_InputFieldId",
                table: "FieldSubmission",
                column: "InputFieldId",
                principalTable: "InputFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSubmission_SelectField_SelectFieldId",
                table: "FieldSubmission",
                column: "SelectFieldId",
                principalTable: "SelectField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSubmission_Submissions_SubmissionId",
                table: "FieldSubmission",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSubmission_WorkEntityField_WorkEntityFieldId",
                table: "FieldSubmission",
                column: "WorkEntityFieldId",
                principalTable: "WorkEntityField",
                principalColumn: "Id");
        }
    }
}
