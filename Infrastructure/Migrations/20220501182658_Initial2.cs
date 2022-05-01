using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationGroup_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationGroup_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup",
                column: "ApplicationId",
                principalSchema: "Identity",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationGroup_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationGroup_Applications_ApplicationId",
                schema: "Identity",
                table: "ApplicationGroup",
                column: "ApplicationId",
                principalSchema: "Identity",
                principalTable: "Applications",
                principalColumn: "Id");
        }
    }
}
