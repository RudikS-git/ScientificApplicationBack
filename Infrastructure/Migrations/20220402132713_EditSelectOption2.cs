using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EditSelectOption2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputSubmission_ApplicationSubmissions_SubmissionId",
                schema: "Identity",
                table: "InputSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_SelectSubmission_SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSubmission_ApplicationSubmissions_SubmissionId",
                schema: "Identity",
                table: "SelectSubmission");

            migrationBuilder.DropIndex(
                name: "IX_SelectOptions_SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions");

            migrationBuilder.DropColumn(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions");

            migrationBuilder.RenameColumn(
                name: "SubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                newName: "ApplicationSubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectSubmission_SubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                newName: "IX_SelectSubmission_ApplicationSubmissionId");

            migrationBuilder.RenameColumn(
                name: "SubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                newName: "ApplicationSubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_InputSubmission_SubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                newName: "IX_InputSubmission_ApplicationSubmissionId");

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
                name: "IX_SelectSubmissonOptions_SelectOptionId",
                schema: "Identity",
                table: "SelectSubmissonOptions",
                column: "SelectOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectSubmissonOptions_SelectSubmissionId",
                schema: "Identity",
                table: "SelectSubmissonOptions",
                column: "SelectSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputSubmission_ApplicationSubmissions_ApplicationSubmissio~",
                schema: "Identity",
                table: "InputSubmission",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectSubmission_ApplicationSubmissions_ApplicationSubmissi~",
                schema: "Identity",
                table: "SelectSubmission",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputSubmission_ApplicationSubmissions_ApplicationSubmissio~",
                schema: "Identity",
                table: "InputSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSubmission_ApplicationSubmissions_ApplicationSubmissi~",
                schema: "Identity",
                table: "SelectSubmission");

            migrationBuilder.DropTable(
                name: "SelectSubmissonOptions",
                schema: "Identity");

            migrationBuilder.RenameColumn(
                name: "ApplicationSubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                newName: "SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_SelectSubmission_ApplicationSubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                newName: "IX_SelectSubmission_SubmissionId");

            migrationBuilder.RenameColumn(
                name: "ApplicationSubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                newName: "SubmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_InputSubmission_ApplicationSubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                newName: "IX_InputSubmission_SubmissionId");

            migrationBuilder.AddColumn<int>(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions",
                column: "SelectSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputSubmission_ApplicationSubmissions_SubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                column: "SubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_SelectSubmission_SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions",
                column: "SelectSubmissionId",
                principalSchema: "Identity",
                principalTable: "SelectSubmission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectSubmission_ApplicationSubmissions_SubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                column: "SubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
