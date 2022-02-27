using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_Submissions_SubmissionId",
                table: "HistoryApplicationState");

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

            migrationBuilder.DropTable(
                name: "EntityFieldSelectField");

            migrationBuilder.DropTable(
                name: "EntityField");

            migrationBuilder.RenameColumn(
                name: "EntityFieldId",
                table: "InputTextField",
                newName: "FieldSetId");

            migrationBuilder.RenameIndex(
                name: "IX_InputTextField_EntityFieldId",
                table: "InputTextField",
                newName: "IX_InputTextField_FieldSetId");

            migrationBuilder.RenameColumn(
                name: "EntityFieldId",
                table: "InputNumberPhoneField",
                newName: "FieldSetId");

            migrationBuilder.RenameIndex(
                name: "IX_InputNumberPhoneField_EntityFieldId",
                table: "InputNumberPhoneField",
                newName: "IX_InputNumberPhoneField_FieldSetId");

            migrationBuilder.RenameColumn(
                name: "EntityFieldId",
                table: "InputNumberField",
                newName: "FieldSetId");

            migrationBuilder.RenameIndex(
                name: "IX_InputNumberField_EntityFieldId",
                table: "InputNumberField",
                newName: "IX_InputNumberField_FieldSetId");

            migrationBuilder.RenameColumn(
                name: "EntityFieldId",
                table: "InputDateField",
                newName: "FieldSetId");

            migrationBuilder.RenameIndex(
                name: "IX_InputDateField_EntityFieldId",
                table: "InputDateField",
                newName: "IX_InputDateField_FieldSetId");

            migrationBuilder.RenameColumn(
                name: "SubmissionId",
                table: "HistoryApplicationState",
                newName: "ApplicationSubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_SubmissionId",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_ApplicationSubmissionId");

            migrationBuilder.CreateTable(
                name: "FieldSet",
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
                    table.PrimaryKey("PK_FieldSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldSet_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldSet_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldSet_SelectSubmission_SelectSubmissionId",
                        column: x => x.SelectSubmissionId,
                        principalTable: "SelectSubmission",
                        principalColumn: "Id");
                });

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
                name: "IX_FieldSet_ApplicationGroupId",
                table: "FieldSet",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_FieldTypeId",
                table: "FieldSet",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_SelectSubmissionId",
                table: "FieldSet",
                column: "SelectSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSetSelectField_SelectFieldsId",
                table: "FieldSetSelectField",
                column: "SelectFieldsId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_Submissions_ApplicationSubmissionId",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputDateField_FieldSet_FieldSetId",
                table: "InputDateField",
                column: "FieldSetId",
                principalTable: "FieldSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputNumberField_FieldSet_FieldSetId",
                table: "InputNumberField",
                column: "FieldSetId",
                principalTable: "FieldSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputNumberPhoneField_FieldSet_FieldSetId",
                table: "InputNumberPhoneField",
                column: "FieldSetId",
                principalTable: "FieldSet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputTextField_FieldSet_FieldSetId",
                table: "InputTextField",
                column: "FieldSetId",
                principalTable: "FieldSet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_Submissions_ApplicationSubmissionId",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_InputDateField_FieldSet_FieldSetId",
                table: "InputDateField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputNumberField_FieldSet_FieldSetId",
                table: "InputNumberField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputNumberPhoneField_FieldSet_FieldSetId",
                table: "InputNumberPhoneField");

            migrationBuilder.DropForeignKey(
                name: "FK_InputTextField_FieldSet_FieldSetId",
                table: "InputTextField");

            migrationBuilder.DropTable(
                name: "FieldSetSelectField");

            migrationBuilder.DropTable(
                name: "FieldSet");

            migrationBuilder.RenameColumn(
                name: "FieldSetId",
                table: "InputTextField",
                newName: "EntityFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_InputTextField_FieldSetId",
                table: "InputTextField",
                newName: "IX_InputTextField_EntityFieldId");

            migrationBuilder.RenameColumn(
                name: "FieldSetId",
                table: "InputNumberPhoneField",
                newName: "EntityFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_InputNumberPhoneField_FieldSetId",
                table: "InputNumberPhoneField",
                newName: "IX_InputNumberPhoneField_EntityFieldId");

            migrationBuilder.RenameColumn(
                name: "FieldSetId",
                table: "InputNumberField",
                newName: "EntityFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_InputNumberField_FieldSetId",
                table: "InputNumberField",
                newName: "IX_InputNumberField_EntityFieldId");

            migrationBuilder.RenameColumn(
                name: "FieldSetId",
                table: "InputDateField",
                newName: "EntityFieldId");

            migrationBuilder.RenameIndex(
                name: "IX_InputDateField_FieldSetId",
                table: "InputDateField",
                newName: "IX_InputDateField_EntityFieldId");

            migrationBuilder.RenameColumn(
                name: "ApplicationSubmissionId",
                table: "HistoryApplicationState",
                newName: "SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_ApplicationSubmissionId",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_SubmissionId");

            migrationBuilder.CreateTable(
                name: "EntityField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    FieldTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SelectSubmissionId = table.Column<int>(type: "integer", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_Submissions_SubmissionId",
                table: "HistoryApplicationState",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "Id");

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
        }
    }
}
