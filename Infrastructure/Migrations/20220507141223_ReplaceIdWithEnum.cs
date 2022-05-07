using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class ReplaceIdWithEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_LastApplicationSt~",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_ApplicationSubmissions_ApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationState_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryApplicationState",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.RenameTable(
                name: "HistoryApplicationState",
                schema: "Identity",
                newName: "HistoryApplicationStates",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_NewApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                newName: "IX_HistoryApplicationStates_NewApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_LastApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                newName: "IX_HistoryApplicationStates_LastApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                newName: "IX_HistoryApplicationStates_ChangedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationState_ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                newName: "IX_HistoryApplicationStates_ApplicationSubmissionId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Identity",
                table: "ApplicationStates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NewApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryApplicationStates",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationStates_LastApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "LastApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationStates_NewApplicationSt~",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "NewApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ChangedUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationStates_LastApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationStates_NewApplicationSt~",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_ApplicationSubmissions_Application~",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HistoryApplicationStates",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.RenameTable(
                name: "HistoryApplicationStates",
                schema: "Identity",
                newName: "HistoryApplicationState",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationStates_NewApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_NewApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationStates_LastApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_LastApplicationStateId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationStates_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_ChangedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_HistoryApplicationStates_ApplicationSubmissionId",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "IX_HistoryApplicationState_ApplicationSubmissionId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Identity",
                table: "ApplicationStates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NewApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "LastApplicationStateId",
                schema: "Identity",
                table: "HistoryApplicationState",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationState",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HistoryApplicationState",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_LastApplicationSt~",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "LastApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationStates_NewApplicationSta~",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "NewApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_ApplicationSubmissions_ApplicationS~",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ApplicationSubmissionId",
                principalSchema: "Identity",
                principalTable: "ApplicationSubmissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationState_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationState",
                column: "ChangedUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
