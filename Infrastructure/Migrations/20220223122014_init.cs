using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputUnderType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputUnderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectRestriction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaxCount = table.Column<int>(type: "integer", nullable: false),
                    MinCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectRestriction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExternalId = table.Column<int>(type: "integer", nullable: false),
                    FirstActivity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CC_FirstActivityLastActivity", "\"FirstActivity\" <= \"LastActivity\"");
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PermissionId = table.Column<int>(type: "integer", nullable: true),
                    IsRemoved = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionUser",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUser", x => new { x.PermissionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermissionUser_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ApplicationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationGroup_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    IsRemoved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_ApplicationState_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Submissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputUnderTypeId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MinDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaxDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InputDate_InputFieldId = table.Column<int>(type: "integer", nullable: true),
                    Min = table.Column<int>(type: "integer", nullable: true),
                    Max = table.Column<int>(type: "integer", nullable: true),
                    InputNumber_InputFieldId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    InputNumberPhone_InputFieldId = table.Column<int>(type: "integer", nullable: true),
                    MaxLength = table.Column<int>(type: "integer", nullable: true),
                    MinLength = table.Column<int>(type: "integer", nullable: true),
                    InputFieldId = table.Column<int>(type: "integer", nullable: true),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    FieldTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputFields_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_InputFields_InputDate_InputFieldId",
                        column: x => x.InputDate_InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_InputFields_InputNumber_InputFieldId",
                        column: x => x.InputNumber_InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_InputFields_InputNumberPhone_InputFieldId",
                        column: x => x.InputNumberPhone_InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputFields_InputUnderType_InputUnderTypeId",
                        column: x => x.InputUnderTypeId,
                        principalTable: "InputUnderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsMultiple = table.Column<bool>(type: "boolean", nullable: false),
                    IsAsync = table.Column<bool>(type: "boolean", nullable: false),
                    SelectRestrictionId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    FieldTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectField_FieldTypes_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectField_SelectRestriction_SelectRestrictionId",
                        column: x => x.SelectRestrictionId,
                        principalTable: "SelectRestriction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryApplicationState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    NewApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    ChangedUserId = table.Column<int>(type: "integer", nullable: true),
                    SubmissionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryApplicationState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationState_LastApplicationSta~",
                        column: x => x.LastApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationState_NewApplicationStat~",
                        column: x => x.NewApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_Users_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmissionId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    WorkEntityFieldId = table.Column<int>(type: "integer", nullable: true),
                    InputFieldId = table.Column<int>(type: "integer", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldSubmission_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldSubmission_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalTable: "SelectField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldSubmission_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "ApplicationState",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Черновик" },
                    { 2, "На проверке" },
                    { 3, "Отклонено" },
                    { 4, "Отправлено на доработку" },
                    { 5, "Согласовано" }
                });

            migrationBuilder.InsertData(
                table: "FieldTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Input" },
                    { 2, "Select" },
                    { 3, "Entity" }
                });

            migrationBuilder.InsertData(
                table: "InputUnderType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Text" },
                    { 2, "Date" },
                    { 3, "Time" },
                    { 4, "DateTime" },
                    { 5, "NumberPhone" },
                    { 6, "Email" },
                    { 7, "Number" },
                    { 8, "Float number" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationGroup_ApplicationId",
                table: "ApplicationGroup",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PermissionId",
                table: "Applications",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_InputFieldId",
                table: "FieldSubmission",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_SelectFieldId",
                table: "FieldSubmission",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_SubmissionId",
                table: "FieldSubmission",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSubmission_WorkEntityFieldId",
                table: "FieldSubmission",
                column: "WorkEntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_ChangedUserId",
                table: "HistoryApplicationState",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_LastApplicationStateId",
                table: "HistoryApplicationState",
                column: "LastApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_NewApplicationStateId",
                table: "HistoryApplicationState",
                column: "NewApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_SubmissionId",
                table: "HistoryApplicationState",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_ApplicationGroupId",
                table: "InputFields",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_FieldTypeId",
                table: "InputFields",
                column: "FieldTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_InputUnderTypeId",
                table: "InputFields",
                column: "InputUnderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UsersId",
                table: "PermissionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_ApplicationGroupId",
                table: "SelectField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_FieldTypeId",
                table: "SelectField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_SelectRestrictionId",
                table: "SelectField",
                column: "SelectRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ApplicationId",
                table: "Submissions",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ApplicationStateId",
                table: "Submissions",
                column: "ApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");

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
                name: "FK_FieldSubmission_WorkEntityField_WorkEntityFieldId",
                table: "FieldSubmission",
                column: "WorkEntityFieldId",
                principalTable: "WorkEntityField",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationGroup_Applications_ApplicationId",
                table: "ApplicationGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Applications_ApplicationId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Users_UserId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_InputFields_InputFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_SelectField_SelectFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkEntityField_SelectField_SelectFieldId",
                table: "WorkEntityField");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_Submissions_SubmissionId",
                table: "FieldSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSubmission_WorkEntityField_WorkEntityFieldId",
                table: "FieldSubmission");

            migrationBuilder.DropTable(
                name: "HistoryApplicationState");

            migrationBuilder.DropTable(
                name: "PermissionUser");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InputFields");

            migrationBuilder.DropTable(
                name: "InputUnderType");

            migrationBuilder.DropTable(
                name: "SelectField");

            migrationBuilder.DropTable(
                name: "ApplicationGroup");

            migrationBuilder.DropTable(
                name: "SelectRestriction");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "ApplicationState");

            migrationBuilder.DropTable(
                name: "WorkEntityField");

            migrationBuilder.DropTable(
                name: "FieldSubmission");

            migrationBuilder.DropTable(
                name: "FieldTypes");
        }
    }
}
