using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddAppSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldSet_SelectSubmission_SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_Submissions_ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_InputSubmission_Submissions_SubmissionId",
                schema: "Identity",
                table: "InputSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectSubmission_Submissions_SubmissionId",
                schema: "Identity",
                table: "SelectSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Applications_ApplicationId",
                schema: "Identity",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_AspNetUsers_UserId",
                schema: "Identity",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_FieldSet_SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submissions",
                schema: "Identity",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet");

            migrationBuilder.RenameTable(
                name: "Submissions",
                schema: "Identity",
                newName: "ApplicationSubmissions",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                newName: "IX_ApplicationSubmissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                newName: "IX_ApplicationSubmissions_ApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_ApplicationId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                newName: "IX_ApplicationSubmissions_ApplicationId");

            migrationBuilder.AddColumn<int>(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationSubmissions",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions",
                column: "SelectSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationId",
                principalSchema: "Identity",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_AspNetUsers_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationSubmissions_ApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_AspNetUsers_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationSubmissions_ApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationState");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationSubmissions",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropColumn(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "SelectOptions");

            migrationBuilder.RenameTable(
                name: "ApplicationSubmissions",
                schema: "Identity",
                newName: "Submissions",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationSubmissions_UserId",
                schema: "Identity",
                table: "Submissions",
                newName: "IX_Submissions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationSubmissions_ApplicationStateId",
                schema: "Identity",
                table: "Submissions",
                newName: "IX_Submissions_ApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationSubmissions_ApplicationId",
                schema: "Identity",
                table: "Submissions",
                newName: "IX_Submissions_ApplicationId");

            migrationBuilder.AddColumn<int>(
                name: "SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submissions",
                schema: "Identity",
                table: "Submissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FieldSet_SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet",
                column: "SelectSubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldSet_SelectSubmission_SelectSubmissionId",
                schema: "Identity",
                table: "FieldSet",
                column: "SelectSubmissionId",
                principalSchema: "Identity",
                principalTable: "SelectSubmission",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_Submissions_ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "Submissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputSubmission_Submissions_SubmissionId",
                schema: "Identity",
                table: "InputSubmission",
                column: "SubmissionId",
                principalSchema: "Identity",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectSubmission_Submissions_SubmissionId",
                schema: "Identity",
                table: "SelectSubmission",
                column: "SubmissionId",
                principalSchema: "Identity",
                principalTable: "Submissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Applications_ApplicationId",
                schema: "Identity",
                table: "Submissions",
                column: "ApplicationId",
                principalSchema: "Identity",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "Submissions",
                column: "ApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_AspNetUsers_UserId",
                schema: "Identity",
                table: "Submissions",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
