using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_types_UserTypeId",
                table: "users");

            migrationBuilder.DropTable(
                name: "users_types");

            migrationBuilder.CreateTable(
                name: "users_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PermissionXuserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_type_permissionsXuser_PermissionXuserTypeId",
                        column: x => x.PermissionXuserTypeId,
                        principalTable: "permissionsXuser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_type_PermissionXuserTypeId",
                table: "users_type",
                column: "PermissionXuserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_type_UserTypeId",
                table: "users",
                column: "UserTypeId",
                principalTable: "users_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_type_UserTypeId",
                table: "users");

            migrationBuilder.DropTable(
                name: "users_type");

            migrationBuilder.CreateTable(
                name: "users_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionXuserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_types_permissionsXuser_PermissionXuserTypeId",
                        column: x => x.PermissionXuserTypeId,
                        principalTable: "permissionsXuser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_types_PermissionXuserTypeId",
                table: "users_types",
                column: "PermissionXuserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_types_UserTypeId",
                table: "users",
                column: "UserTypeId",
                principalTable: "users_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
