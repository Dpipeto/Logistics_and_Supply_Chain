using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateusertypesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_type_UserTypeId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_type_permissionsXuser_PermissionXuserTypeId",
                table: "users_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users_type",
                table: "users_type");

            migrationBuilder.RenameTable(
                name: "users_type",
                newName: "usersTypes");

            migrationBuilder.RenameIndex(
                name: "IX_users_type_PermissionXuserTypeId",
                table: "usersTypes",
                newName: "IX_usersTypes_PermissionXuserTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usersTypes",
                table: "usersTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_usersTypes_UserTypeId",
                table: "users",
                column: "UserTypeId",
                principalTable: "usersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usersTypes_permissionsXuser_PermissionXuserTypeId",
                table: "usersTypes",
                column: "PermissionXuserTypeId",
                principalTable: "permissionsXuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_usersTypes_UserTypeId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_usersTypes_permissionsXuser_PermissionXuserTypeId",
                table: "usersTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usersTypes",
                table: "usersTypes");

            migrationBuilder.RenameTable(
                name: "usersTypes",
                newName: "users_type");

            migrationBuilder.RenameIndex(
                name: "IX_usersTypes_PermissionXuserTypeId",
                table: "users_type",
                newName: "IX_users_type_PermissionXuserTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users_type",
                table: "users_type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_type_UserTypeId",
                table: "users",
                column: "UserTypeId",
                principalTable: "users_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_type_permissionsXuser_PermissionXuserTypeId",
                table: "users_type",
                column: "PermissionXuserTypeId",
                principalTable: "permissionsXuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
