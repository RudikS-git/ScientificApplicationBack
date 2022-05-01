using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "ApplicationStates",
                schema: "Identity",
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
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonName_FirstName = table.Column<string>(type: "text", nullable: true),
                    PersonName_LastName = table.Column<string>(type: "text", nullable: true),
                    PersonName_Patronymic = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                schema: "Identity",
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
                name: "Permission",
                schema: "Identity",
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
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectRestriction",
                schema: "Identity",
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
                name: "RefreshTokens",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: true),
                    Revoked = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                schema: "Identity",
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
                        name: "FK_Applications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Identity",
                        principalTable: "Permission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermissionUser",
                schema: "Identity",
                columns: table => new
                {
                    PermissionsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUser", x => new { x.PermissionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PermissionUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionUser_Permission_PermissionsId",
                        column: x => x.PermissionsId,
                        principalSchema: "Identity",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationGroup",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Applications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationSubmissions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    IsRemoved = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationSubmissions_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "Identity",
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationSubmissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldSet",
                schema: "Identity",
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
                    table.PrimaryKey("PK_FieldSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldSet_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputFields",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputUnderTypeId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_InputFields_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryApplicationState",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                        column: x => x.NewApplicationStateId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_ApplicationSubmissions_ApplicationS~",
                        column: x => x.ApplicationSubmissionId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationSubmissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoryApplicationState_AspNetUsers_ChangedUserId",
                        column: x => x.ChangedUserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectField",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalSchema: "Identity",
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectField_SelectRestriction_SelectRestrictionId",
                        column: x => x.SelectRestrictionId,
                        principalSchema: "Identity",
                        principalTable: "SelectRestriction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputDateField",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    MinDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputDateField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputDateField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputDateField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalSchema: "Identity",
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputDateField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalSchema: "Identity",
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputNumberField",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    Min = table.Column<int>(type: "integer", nullable: false),
                    Max = table.Column<int>(type: "integer", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputNumberField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalSchema: "Identity",
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputNumberField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalSchema: "Identity",
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputNumberPhoneField",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputNumberPhoneField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalSchema: "Identity",
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputNumberPhoneField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalSchema: "Identity",
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputSubmission",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ApplicationSubmissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputSubmission_ApplicationSubmissions_ApplicationSubmissio~",
                        column: x => x.ApplicationSubmissionId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputSubmission_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalSchema: "Identity",
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputTextField",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationGroupId = table.Column<int>(type: "integer", nullable: false),
                    MaxLength = table.Column<int>(type: "integer", nullable: false),
                    MinLength = table.Column<int>(type: "integer", nullable: false),
                    InputFieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldSetId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputTextField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputTextField_ApplicationGroup_ApplicationGroupId",
                        column: x => x.ApplicationGroupId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputTextField_FieldSet_FieldSetId",
                        column: x => x.FieldSetId,
                        principalSchema: "Identity",
                        principalTable: "FieldSet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InputTextField_InputFields_InputFieldId",
                        column: x => x.InputFieldId,
                        principalSchema: "Identity",
                        principalTable: "InputFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectOptions",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "SelectField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SelectSubmission",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectFieldId = table.Column<int>(type: "integer", nullable: false),
                    ApplicationSubmissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectSubmission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectSubmission_ApplicationSubmissions_ApplicationSubmissi~",
                        column: x => x.ApplicationSubmissionId,
                        principalSchema: "Identity",
                        principalTable: "ApplicationSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectSubmission_SelectField_SelectFieldId",
                        column: x => x.SelectFieldId,
                        principalSchema: "Identity",
                        principalTable: "SelectField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectSubmissonOptions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectSubmissionId = table.Column<int>(type: "integer", nullable: false),
                    SelectOptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectSubmissonOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectSubmissonOptions_SelectOptions_SelectOptionId",
                        column: x => x.SelectOptionId,
                        principalSchema: "Identity",
                        principalTable: "SelectOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectSubmissonOptions_SelectSubmission_SelectSubmissionId",
                        column: x => x.SelectSubmissionId,
                        principalSchema: "Identity",
                        principalTable: "SelectSubmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationGroup_ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PermissionId",
                schema: "Identity",
                table: "Applications",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                schema: "Identity",
                table: "Applications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSubmissions_ApplicationId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSubmissions_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationSubmissions_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_ApplicationGroupId",
                schema: "Identity",
                table: "FieldSet",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ChangedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_LastApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "LastApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryApplicationState_NewApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "NewApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_ApplicationGroupId",
                schema: "Identity",
                table: "InputDateField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_FieldSetId",
                schema: "Identity",
                table: "InputDateField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputDateField_InputFieldId",
                schema: "Identity",
                table: "InputDateField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputFields_ApplicationGroupId",
                schema: "Identity",
                table: "InputFields",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_ApplicationGroupId",
                schema: "Identity",
                table: "InputNumberField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_FieldSetId",
                schema: "Identity",
                table: "InputNumberField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberField_InputFieldId",
                schema: "Identity",
                table: "InputNumberField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_ApplicationGroupId",
                schema: "Identity",
                table: "InputNumberPhoneField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_FieldSetId",
                schema: "Identity",
                table: "InputNumberPhoneField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputNumberPhoneField_InputFieldId",
                schema: "Identity",
                table: "InputNumberPhoneField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_ApplicationSubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                column: "ApplicationSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_InputSubmission_InputFieldId",
                schema: "Identity",
                table: "InputSubmission",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_ApplicationGroupId",
                schema: "Identity",
                table: "InputTextField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_FieldSetId",
                schema: "Identity",
                table: "InputTextField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_InputTextField_InputFieldId",
                schema: "Identity",
                table: "InputTextField",
                column: "InputFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUser_UsersId",
                schema: "Identity",
                table: "PermissionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "Identity",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_ApplicationGroupId",
                schema: "Identity",
                table: "SelectField",
                column: "ApplicationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_FieldSetId",
                schema: "Identity",
                table: "SelectField",
                column: "FieldSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectField_SelectRestrictionId",
                schema: "Identity",
                table: "SelectField",
                column: "SelectRestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_SelectFieldId",
                schema: "Identity",
                table: "SelectOptions",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmission_ApplicationSubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                column: "ApplicationSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmission_SelectFieldId",
                schema: "Identity",
                table: "SelectSubmission",
                column: "SelectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmissonOptions_SelectOptionId",
                schema: "Identity",
                table: "SelectSubmissonOptions",
                column: "SelectOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmissonOptions_SelectSubmissionId",
                schema: "Identity",
                table: "SelectSubmissonOptions",
                column: "SelectSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldTypes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "HistoryApplicationState",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputDateField",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputNumberField",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputNumberPhoneField",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputSubmission",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputTextField",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PermissionUser",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SelectSubmissonOptions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "InputFields",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SelectOptions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SelectSubmission",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ApplicationSubmissions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SelectField",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ApplicationStates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FieldSet",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SelectRestriction",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ApplicationGroup",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Applications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Identity");
        }
    }
}
