using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Appsub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id");
        }
    }
}
