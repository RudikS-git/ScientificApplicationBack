using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStates", x => x.Id);
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
                name: "InputFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Style_Order = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputFields", x => x.Id);
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonName_FirstName = table.Column<string>(type: "text", nullable: true),
                    PersonName_LastName = table.Column<string>(type: "text", nullable: true),
                    PersonName_Patronymic = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Applications_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                        name: "FK_PermissionUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                        name: "FK_Submissions_ApplicationStates_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Submissions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    ApplicationSubmissionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryApplicationState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationStates_LastApplicationSt~",
                        column: x => x.LastApplicationStateId,
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                        column: x => x.NewApplicationStateId,
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_Submissions_ApplicationSubmissionId",
                        column: x => x.ApplicationSubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_User_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalTable: "User",
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
                name: "FieldSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectSubmissionId = table.Column<int>(type: "integer", nullable: true),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Style_Order = table.Column<int>(type: "integer", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "InputDateField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MinDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDateField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputDateField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id");
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
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id");
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
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberPhoneField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id");
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
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTextField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputTextField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "SelectField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsMultiple = table.Column<bool>(type: "boolean", nullable: false),
                    IsAsync = table.Column<bool>(type: "boolean", nullable: false),
                    SelectRestrictionId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    SystemName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Style_Order = table.Column<int>(type: "integer", nullable: true)
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
                        name: "FK_SelectField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectField_SelectRestriction_SelectRestrictionId",
                        column: x => x.SelectRestrictionId,
                        principalTable: "SelectRestriction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectOptions_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalTable: "SelectField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectSubmission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: false),
                    SubmissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectSubmission_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalTable: "SelectField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectSubmission_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_FieldSet_ApplicationGroupId",
                table: "FieldSet",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_SelectSubmissionId",
                table: "FieldSet",
                column: "SelectSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_ApplicationSubmissionId",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId");

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
                name: "IX_InputDateField_FieldSetId",
                table: "InputDateField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_InputFieldId",
                table: "InputDateField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_FieldSetId",
                table: "InputNumberField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_InputFieldId",
                table: "InputNumberField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_FieldSetId",
                table: "InputNumberPhoneField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_InputFieldId",
                table: "InputNumberPhoneField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_InputFieldId",
                table: "InputSubmission",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_SubmissionId",
                table: "InputSubmission",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_FieldSetId",
                table: "InputTextField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_InputFieldId",
                table: "InputTextField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UsersId",
                table: "PermissionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_ApplicationGroupId",
                table: "SelectField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_FieldSetId",
                table: "SelectField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_SelectRestrictionId",
                table: "SelectField",
                column: "SelectRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_SelectFieldId",
                table: "SelectOptions",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmission_SelectFieldId",
                table: "SelectSubmission",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmission_SubmissionId",
                table: "SelectSubmission",
                column: "SubmissionId");

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
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSet_SelectSubmission_SelectSubmissionId",
                table: "FieldSet",
                column: "SelectSubmissionId",
                principalTable: "SelectSubmission",
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
                name: "FK_Submissions_User_UserId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSet_ApplicationGroup_ApplicationGroupId",
                table: "FieldSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectField_ApplicationGroup_ApplicationGroupId",
                table: "SelectField");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldSet_SelectSubmission_SelectSubmissionId",
                table: "FieldSet");

            migrationBuilder.DropTable(
                name: "FieldTypes");

            migrationBuilder.DropTable(
                name: "HistoryApplicationState");

            migrationBuilder.DropTable(
                name: "InputDateField");

            migrationBuilder.DropTable(
                name: "InputNumberField");

            migrationBuilder.DropTable(
                name: "InputNumberPhoneField");

            migrationBuilder.DropTable(
                name: "InputSubmission");

            migrationBuilder.DropTable(
                name: "InputTextField");

            migrationBuilder.DropTable(
                name: "PermissionUser");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SelectOptions");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "InputFields");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ApplicationGroup");

            migrationBuilder.DropTable(
                name: "SelectSubmission");

            migrationBuilder.DropTable(
                name: "SelectField");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "FieldSet");

            migrationBuilder.DropTable(
                name: "SelectRestriction");

            migrationBuilder.DropTable(
                name: "ApplicationStates");
        }
    }
}
