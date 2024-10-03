using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class histories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userHistories_usersTypes_UserTypeId",
                table: "userHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_userHistories_users_UserId",
                table: "userHistories");

            migrationBuilder.DropIndex(
                name: "IX_userHistories_UserId",
                table: "userHistories");

            migrationBuilder.DropIndex(
                name: "IX_userHistories_UserTypeId",
                table: "userHistories");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "userHistories",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "UserTypeId",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "First_Name",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ID_Document",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Last_Name",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserTypes",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "userHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "dealers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orderDetailHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    DeliveriTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetailHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dealers_UserId",
                table: "dealers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_dealers_users_UserId",
                table: "dealers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dealers_users_UserId",
                table: "dealers");

            migrationBuilder.DropTable(
                name: "orderDetailHistories");

            migrationBuilder.DropIndex(
                name: "IX_dealers_UserId",
                table: "dealers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "First_Name",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "ID_Document",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "Last_Name",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "UserTypes",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "userHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "dealers");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "userHistories",
                newName: "password");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "userHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_userHistories_UserId",
                table: "userHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userHistories_UserTypeId",
                table: "userHistories",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_userHistories_usersTypes_UserTypeId",
                table: "userHistories",
                column: "UserTypeId",
                principalTable: "usersTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userHistories_users_UserId",
                table: "userHistories",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
