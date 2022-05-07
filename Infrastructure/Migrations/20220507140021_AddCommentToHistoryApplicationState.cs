using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddCommentToHistoryApplicationState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creation",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "Updated");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                schema: "Identity",
                table: "HistoryApplicationState",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Identity",
                table: "HistoryApplicationState",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Identity",
                table: "HistoryApplicationState");

            migrationBuilder.RenameColumn(
                name: "Updated",
                schema: "Identity",
                table: "HistoryApplicationState",
                newName: "Creation");
        }
    }
}
