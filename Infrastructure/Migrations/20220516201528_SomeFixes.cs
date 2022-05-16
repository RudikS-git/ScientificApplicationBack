using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                schema: "Identity",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_AspNetUsers_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UsersId",
                schema: "Identity",
                table: "PermissionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity",
                newName: "User",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "Identity",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_User_UserId",
                schema: "Identity",
                table: "Applications",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationSubmissions_User_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_User_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ChangedUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUser_User_UsersId",
                schema: "Identity",
                table: "PermissionUser",
                column: "UsersId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                schema: "Identity",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "Identity",
                table: "UserRole",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId1",
                schema: "Identity",
                table: "UserRole",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_User_UserId",
                schema: "Identity",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationSubmissions_User_UserId",
                schema: "Identity",
                table: "ApplicationSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                schema: "Identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoryApplicationStates_User_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUser_User_UsersId",
                schema: "Identity",
                table: "PermissionUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_User_UserId",
                schema: "Identity",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_User_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_User_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId1",
                schema: "Identity",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_User_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "Identity",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "Identity",
                newName: "AspNetUsers",
                newSchema: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "Identity",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_AspNetUsers_UserId",
                schema: "Identity",
                table: "Applications",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
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
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryApplicationStates_AspNetUsers_ChangedUserId",
                schema: "Identity",
                table: "HistoryApplicationStates",
                column: "ChangedUserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUser_AspNetUsers_UsersId",
                schema: "Identity",
                table: "PermissionUser",
                column: "UsersId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "RefreshTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRole",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_AspNetUsers_UserId1",
                schema: "Identity",
                table: "UserRole",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
