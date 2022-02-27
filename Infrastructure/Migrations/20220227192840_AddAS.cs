using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationState_LastApplicationSta~",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationState_NewApplicationStat~",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_ApplicationState_ApplicationStateId",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationState",
                table: "ApplicationState");

            migrationBuilder.RenameTable(
                name: "ApplicationState",
                newName: "ApplicationStates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationStates",
                table: "ApplicationStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_LastApplicationSt~",
                table: "HistoryApplicationState",
                column: "LastApplicationStateId",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                table: "HistoryApplicationState",
                column: "NewApplicationStateId",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_ApplicationStates_ApplicationStateId",
                table: "Submissions",
                column: "ApplicationStateId",
                principalTable: "ApplicationStates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_LastApplicationSt~",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_ApplicationStates_ApplicationStateId",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationStates",
                table: "ApplicationStates");

            migrationBuilder.RenameTable(
                name: "ApplicationStates",
                newName: "ApplicationState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationState",
                table: "ApplicationState",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationState_LastApplicationSta~",
                table: "HistoryApplicationState",
                column: "LastApplicationStateId",
                principalTable: "ApplicationState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationState_NewApplicationStat~",
                table: "HistoryApplicationState",
                column: "NewApplicationStateId",
                principalTable: "ApplicationState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_ApplicationState_ApplicationStateId",
                table: "Submissions",
                column: "ApplicationStateId",
                principalTable: "ApplicationState",
                principalColumn: "Id");
        }
    }
}
