using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "users_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_types", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_UserTypeId",
                table: "users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_types_UserTypeId",
                table: "users",
                column: "UserTypeId",
                principalTable: "users_types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_types_UserTypeId",
                table: "users");

            migrationBuilder.DropTable(
                name: "users_types");

            migrationBuilder.DropIndex(
                name: "IX_users_UserTypeId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "users");
        }
    }
}
