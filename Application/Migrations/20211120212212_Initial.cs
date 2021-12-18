using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Application.Migrations
{
    public partial class Initial : Migration
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
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchScience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchScience", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CriticalTechnology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriticalTechnology", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Efficiency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureTypeEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureTypeEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Patronymic = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    AcademicDegree = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    AcademicRank = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriorityDirection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReadinessDegree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadinessDegree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchDirection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchDirection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeResearch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstActivity = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CC_FirstActivityLastActivity", "\"FirstActivity\" <= \"LastActivity\"");
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    YearOfFoundation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AnnotatedDescription = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Story = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchools_ApplicationState_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ResearchDirectionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureProjects_ApplicationState_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureProjects_ResearchDirection_ResearchDirectionId",
                        column: x => x.ResearchDirectionId,
                        principalTable: "ResearchDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeDevelopments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationStateId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    StartWork = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndWork = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    BranchScienceId = table.Column<int>(type: "integer", nullable: true),
                    PriorityDirectionId = table.Column<int>(type: "integer", nullable: true),
                    CriticalTechnologyId = table.Column<int>(type: "integer", nullable: true),
                    TypeResearchId = table.Column<int>(type: "integer", nullable: true),
                    EfficiencyId = table.Column<int>(type: "integer", nullable: true),
                    Appointment = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    ApplicationArea = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Specifications = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    ReadinessDegreeId = table.Column<int>(type: "integer", nullable: true),
                    SignsOfTechnicalSolution = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    PositiveResult = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    MethodOfApplication = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Competitiveness = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    EconomicEffect = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    ImplementationExperience = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    SourcesOfFinancing = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_ApplicationState_ApplicationStateId",
                        column: x => x.ApplicationStateId,
                        principalTable: "ApplicationState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_BranchScience_BranchScienceId",
                        column: x => x.BranchScienceId,
                        principalTable: "BranchScience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_CriticalTechnology_CriticalTechnolog~",
                        column: x => x.CriticalTechnologyId,
                        principalTable: "CriticalTechnology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_Efficiency_EfficiencyId",
                        column: x => x.EfficiencyId,
                        principalTable: "Efficiency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_PriorityDirection_PriorityDirectionId",
                        column: x => x.PriorityDirectionId,
                        principalTable: "PriorityDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_ReadinessDegree_ReadinessDegreeId",
                        column: x => x.ReadinessDegreeId,
                        principalTable: "ReadinessDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InnovativeDevelopments_TypeResearch_TypeResearchId",
                        column: x => x.TypeResearchId,
                        principalTable: "TypeResearch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    LeaderId = table.Column<int>(type: "integer", nullable: true),
                    Period = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SourceOfFinancing = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    FundingVolume = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: true),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grant_Member_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grant_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Authors = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Year = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DOI = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Link = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Quartile = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publication_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolBranch_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolDepartment_ScientificSchools_ScientificScho~",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolFounder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolFounder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolFounder_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolFounder_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolGraduateStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolGraduateStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolGraduateStudent_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolGraduateStudent_ScientificSchools_Scientifi~",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolLeader_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolLeader_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificSchoolMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    ScientificSchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificSchoolMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificSchoolMember_ScientificSchools_ScientificSchoolId",
                        column: x => x.ScientificSchoolId,
                        principalTable: "ScientificSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Contract = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: true),
                    Subject = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Sum = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 13, nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureCustomer_InfrastructureProjects_Infrastructur~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructurePhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructurePhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructurePhoto_InfrastructureProjects_InfrastructurePr~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureProjectRealization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureProjectRealization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureProjectRealization_InfrastructureProjects_Inf~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureResearcher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureResearcher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureResearcher_InfrastructureProjects_Infrastruct~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureResearcher_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureScientificLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureScientificLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureScientificLeader_InfrastructureProjects_Infra~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureScientificLeader_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureServiceProvided",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PriorityDirectionId = table.Column<int>(type: "integer", nullable: true),
                    PriorityDirectionNTRRF = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ShortDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureServiceProvided", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureServiceProvided_InfrastructureProjects_Infras~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureServiceProvided_PriorityDirection_PriorityDir~",
                        column: x => x.PriorityDirectionId,
                        principalTable: "PriorityDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureSpecialist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    WorkingConditions = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PrimaryFunctions = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    EducationDescription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureSpecialist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureSpecialist_InfrastructureProjects_Infrastruct~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureTechnicalEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InfrastructureTypeEquipmentId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Year = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Manufacturer = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ApplicationArea = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureTechnicalEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureTechnicalEquipment_InfrastructureProjects_Inf~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureTechnicalEquipment_InfrastructureTypeEquipmen~",
                        column: x => x.InfrastructureTypeEquipmentId,
                        principalTable: "InfrastructureTypeEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureTechnicalLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureTechnicalLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureTechnicalLeader_InfrastructureProjects_Infras~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfrastructureTechnicalLeader_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullScaleSample",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullScaleSample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullScaleSample_InnovativeDevelopments_InnovativeDevelopmen~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRNTI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNTI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GRNTI_InnovativeDevelopments_InnovativeDevelopmentId",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeBranch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeBranch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnovativeBranch_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnovativeBranch_InnovativeDevelopments_InnovativeDevelopme~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnovativeDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnovativeDepartment_InnovativeDevelopments_InnovativeDevel~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnovativeLeader_InnovativeDevelopments_InnovativeDevelopme~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnovativeLeader_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnovativeMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnovativeMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnovativeMember_InnovativeDevelopments_InnovativeDevelopme~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnovativeMember_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Number = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patent_InnovativeDevelopments_InnovativeDevelopmentId",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresentationMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Location = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    InnovativeDevelopmentId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentationMaterial_InnovativeDevelopments_InnovativeDevel~",
                        column: x => x.InnovativeDevelopmentId,
                        principalTable: "InnovativeDevelopments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfrastructureResearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResearcherId = table.Column<int>(type: "integer", nullable: true),
                    Contract = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Subject = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ResearchDirectionId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    InfrastructureProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfrastructureResearch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfrastructureResearch_InfrastructureProjects_Infrastructur~",
                        column: x => x.InfrastructureProjectId,
                        principalTable: "InfrastructureProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureResearch_InfrastructureResearcher_ResearcherId",
                        column: x => x.ResearcherId,
                        principalTable: "InfrastructureResearcher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfrastructureResearch_ResearchDirection_ResearchDirectionId",
                        column: x => x.ResearchDirectionId,
                        principalTable: "ResearchDirection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Name",
                table: "Branch",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchScience_Name",
                table: "BranchScience",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CriticalTechnology_Name",
                table: "CriticalTechnology",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Efficiency_Name",
                table: "Efficiency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FullScaleSample_InnovativeDevelopmentId",
                table: "FullScaleSample",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FullScaleSample_Location",
                table: "FullScaleSample",
                column: "Location",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grant_LeaderId",
                table: "Grant",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Grant_Name",
                table: "Grant",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grant_ScientificSchoolId",
                table: "Grant",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_GRNTI_InnovativeDevelopmentId",
                table: "GRNTI",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GRNTI_Name",
                table: "GRNTI",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureCustomer_InfrastructureProjectId",
                table: "InfrastructureCustomer",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureCustomer_Name",
                table: "InfrastructureCustomer",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructurePhoto_InfrastructureProjectId",
                table: "InfrastructurePhoto",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructurePhoto_Location",
                table: "InfrastructurePhoto",
                column: "Location",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjectRealization_InfrastructureProjectId",
                table: "InfrastructureProjectRealization",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjectRealization_Name",
                table: "InfrastructureProjectRealization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjectRealization_Subject",
                table: "InfrastructureProjectRealization",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjects_ApplicationStateId",
                table: "InfrastructureProjects",
                column: "ApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjects_Name",
                table: "InfrastructureProjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureProjects_ResearchDirectionId",
                table: "InfrastructureProjects",
                column: "ResearchDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearch_InfrastructureProjectId",
                table: "InfrastructureResearch",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearch_Name",
                table: "InfrastructureResearch",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearch_ResearchDirectionId",
                table: "InfrastructureResearch",
                column: "ResearchDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearch_ResearcherId",
                table: "InfrastructureResearch",
                column: "ResearcherId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearcher_InfrastructureProjectId",
                table: "InfrastructureResearcher",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureResearcher_MemberId",
                table: "InfrastructureResearcher",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureScientificLeader_InfrastructureProjectId",
                table: "InfrastructureScientificLeader",
                column: "InfrastructureProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureScientificLeader_MemberId",
                table: "InfrastructureScientificLeader",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureServiceProvided_InfrastructureProjectId",
                table: "InfrastructureServiceProvided",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureServiceProvided_PriorityDirectionId",
                table: "InfrastructureServiceProvided",
                column: "PriorityDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureSpecialist_InfrastructureProjectId",
                table: "InfrastructureSpecialist",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureTechnicalEquipment_InfrastructureProjectId",
                table: "InfrastructureTechnicalEquipment",
                column: "InfrastructureProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureTechnicalEquipment_InfrastructureTypeEquipmen~",
                table: "InfrastructureTechnicalEquipment",
                column: "InfrastructureTypeEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureTechnicalLeader_InfrastructureProjectId",
                table: "InfrastructureTechnicalLeader",
                column: "InfrastructureProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureTechnicalLeader_MemberId",
                table: "InfrastructureTechnicalLeader",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InfrastructureTypeEquipment_Name",
                table: "InfrastructureTypeEquipment",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeBranch_BranchId",
                table: "InnovativeBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeBranch_InnovativeDevelopmentId",
                table: "InnovativeBranch",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDepartment_DepartmentId",
                table: "InnovativeDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDepartment_InnovativeDevelopmentId",
                table: "InnovativeDepartment",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_ApplicationStateId",
                table: "InnovativeDevelopments",
                column: "ApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_BranchScienceId",
                table: "InnovativeDevelopments",
                column: "BranchScienceId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_CriticalTechnologyId",
                table: "InnovativeDevelopments",
                column: "CriticalTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_EfficiencyId",
                table: "InnovativeDevelopments",
                column: "EfficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_Name",
                table: "InnovativeDevelopments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_PriorityDirectionId",
                table: "InnovativeDevelopments",
                column: "PriorityDirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_ReadinessDegreeId",
                table: "InnovativeDevelopments",
                column: "ReadinessDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeDevelopments_TypeResearchId",
                table: "InnovativeDevelopments",
                column: "TypeResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeLeader_InnovativeDevelopmentId",
                table: "InnovativeLeader",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeLeader_MemberId",
                table: "InnovativeLeader",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeMember_InnovativeDevelopmentId",
                table: "InnovativeMember",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InnovativeMember_MemberId",
                table: "InnovativeMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Patent_InnovativeDevelopmentId",
                table: "Patent",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patent_Name",
                table: "Patent",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresentationMaterial_InnovativeDevelopmentId",
                table: "PresentationMaterial",
                column: "InnovativeDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationMaterial_Location",
                table: "PresentationMaterial",
                column: "Location",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriorityDirection_Name",
                table: "PriorityDirection",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_ScientificSchoolId",
                table: "Publication",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ReadinessDegree_Name",
                table: "ReadinessDegree",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchDirection_Name",
                table: "ResearchDirection",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolBranch_BranchId",
                table: "ScientificSchoolBranch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolBranch_ScientificSchoolId",
                table: "ScientificSchoolBranch",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolDepartment_DepartmentId",
                table: "ScientificSchoolDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolDepartment_ScientificSchoolId",
                table: "ScientificSchoolDepartment",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolFounder_MemberId",
                table: "ScientificSchoolFounder",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolFounder_ScientificSchoolId",
                table: "ScientificSchoolFounder",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolGraduateStudent_MemberId",
                table: "ScientificSchoolGraduateStudent",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolGraduateStudent_ScientificSchoolId",
                table: "ScientificSchoolGraduateStudent",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolLeader_MemberId",
                table: "ScientificSchoolLeader",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolLeader_ScientificSchoolId",
                table: "ScientificSchoolLeader",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolMember_MemberId",
                table: "ScientificSchoolMember",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchoolMember_ScientificSchoolId",
                table: "ScientificSchoolMember",
                column: "ScientificSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchools_ApplicationStateId",
                table: "ScientificSchools",
                column: "ApplicationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificSchools_Name",
                table: "ScientificSchools",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeResearch_Name",
                table: "TypeResearch",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullScaleSample");

            migrationBuilder.DropTable(
                name: "Grant");

            migrationBuilder.DropTable(
                name: "GRNTI");

            migrationBuilder.DropTable(
                name: "InfrastructureCustomer");

            migrationBuilder.DropTable(
                name: "InfrastructurePhoto");

            migrationBuilder.DropTable(
                name: "InfrastructureProjectRealization");

            migrationBuilder.DropTable(
                name: "InfrastructureResearch");

            migrationBuilder.DropTable(
                name: "InfrastructureScientificLeader");

            migrationBuilder.DropTable(
                name: "InfrastructureServiceProvided");

            migrationBuilder.DropTable(
                name: "InfrastructureSpecialist");

            migrationBuilder.DropTable(
                name: "InfrastructureTechnicalEquipment");

            migrationBuilder.DropTable(
                name: "InfrastructureTechnicalLeader");

            migrationBuilder.DropTable(
                name: "InnovativeBranch");

            migrationBuilder.DropTable(
                name: "InnovativeDepartment");

            migrationBuilder.DropTable(
                name: "InnovativeLeader");

            migrationBuilder.DropTable(
                name: "InnovativeMember");

            migrationBuilder.DropTable(
                name: "Patent");

            migrationBuilder.DropTable(
                name: "PresentationMaterial");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "ScientificSchoolBranch");

            migrationBuilder.DropTable(
                name: "ScientificSchoolDepartment");

            migrationBuilder.DropTable(
                name: "ScientificSchoolFounder");

            migrationBuilder.DropTable(
                name: "ScientificSchoolGraduateStudent");

            migrationBuilder.DropTable(
                name: "ScientificSchoolLeader");

            migrationBuilder.DropTable(
                name: "ScientificSchoolMember");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InfrastructureResearcher");

            migrationBuilder.DropTable(
                name: "InfrastructureTypeEquipment");

            migrationBuilder.DropTable(
                name: "InnovativeDevelopments");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "ScientificSchools");

            migrationBuilder.DropTable(
                name: "InfrastructureProjects");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "BranchScience");

            migrationBuilder.DropTable(
                name: "CriticalTechnology");

            migrationBuilder.DropTable(
                name: "Efficiency");

            migrationBuilder.DropTable(
                name: "PriorityDirection");

            migrationBuilder.DropTable(
                name: "ReadinessDegree");

            migrationBuilder.DropTable(
                name: "TypeResearch");

            migrationBuilder.DropTable(
                name: "ApplicationState");

            migrationBuilder.DropTable(
                name: "ResearchDirection");
        }
    }
}
