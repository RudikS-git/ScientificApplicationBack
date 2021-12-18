using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class Add_CC_InnovativeDevelopments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CC_StartEndWork",
                table: "InnovativeDevelopments",
                sql: "\"StartWork\" <= \"EndWork\"");

            migrationBuilder.AddCheckConstraint(
                name: "CC_Email",
                table: "InnovativeDevelopments",
                sql: "\"Email\" ~* '^[A-Z0-9._%-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}$)'");

            migrationBuilder.AddCheckConstraint(
                name: "CC_Phone",
                table: "InnovativeDevelopments",
                sql: "\"Phone\" ~* '^[0 - 9\\.] +$)'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CC_StartEndWork",
                table: "InnovativeDevelopments");

            migrationBuilder.DropCheckConstraint(
                name: "CC_Email",
                table: "InnovativeDevelopments");

            migrationBuilder.DropCheckConstraint(
                name: "CC_Phone",
                table: "InnovativeDevelopments");
        }
    }
}
