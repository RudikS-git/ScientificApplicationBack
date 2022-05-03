using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class appSubState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_ApplicationStates_ApplicationStateId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "ApplicationStateId",
                principalSchema: "Identity",
                principalTable: "ApplicationStates",
                principalColumn: "Id");
        }
    }
}
