using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class x : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usersTypes_permissionsXuser_PermissionXuserTypeId",
                table: "usersTypes");

            migrationBuilder.DropIndex(
                name: "IX_usersTypes_PermissionXuserTypeId",
                table: "usersTypes");

            migrationBuilder.DropColumn(
                name: "PermissionXuserTypeId",
                table: "usersTypes");

            migrationBuilder.DropColumn(
                name: "PermissionsXuserType",
                table: "permissionsXuser");

            migrationBuilder.AddColumn<int>(
                name: "UserTypesId",
                table: "permissionsXuser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_permissionsXuser_UserTypesId",
                table: "permissionsXuser",
                column: "UserTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_permissionsXuser_usersTypes_UserTypesId",
                table: "permissionsXuser",
                column: "UserTypesId",
                principalTable: "usersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissionsXuser_usersTypes_UserTypesId",
                table: "permissionsXuser");

            migrationBuilder.DropIndex(
                name: "IX_permissionsXuser_UserTypesId",
                table: "permissionsXuser");

            migrationBuilder.DropColumn(
                name: "UserTypesId",
                table: "permissionsXuser");

            migrationBuilder.AddColumn<int>(
                name: "PermissionXuserTypeId",
                table: "usersTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PermissionsXuserType",
                table: "permissionsXuser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_usersTypes_PermissionXuserTypeId",
                table: "usersTypes",
                column: "PermissionXuserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_usersTypes_permissionsXuser_PermissionXuserTypeId",
                table: "usersTypes",
                column: "PermissionXuserTypeId",
                principalTable: "permissionsXuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
