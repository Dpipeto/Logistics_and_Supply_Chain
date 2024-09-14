using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddModelRelationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionXuserTypeId",
                table: "users_types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "dealers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Delivery_Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_detail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Order = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Package_sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Package_Receive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_orders_detail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "orders_detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_orders_status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "orders_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissionsXuser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionsXuserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionsXuser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permissionsXuser_permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders_tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_tracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_tracking_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_tracking_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_tracking_types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTracking_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_TrackingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_tracking_types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_tracking_types_orders_tracking_Order_TrackingId",
                        column: x => x.Order_TrackingId,
                        principalTable: "orders_tracking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_types_PermissionXuserTypeId",
                table: "users_types",
                column: "PermissionXuserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_order_tracking_types_Order_TrackingId",
                table: "order_tracking_types",
                column: "Order_TrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DetailId",
                table: "orders",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_StatusId",
                table: "orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_UserId",
                table: "orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_tracking_DealerId",
                table: "orders_tracking",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_tracking_OrderId",
                table: "orders_tracking",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_permissionsXuser_PermissionsId",
                table: "permissionsXuser",
                column: "PermissionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_types_permissionsXuser_PermissionXuserTypeId",
                table: "users_types",
                column: "PermissionXuserTypeId",
                principalTable: "permissionsXuser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_types_permissionsXuser_PermissionXuserTypeId",
                table: "users_types");

            migrationBuilder.DropTable(
                name: "order_tracking_types");

            migrationBuilder.DropTable(
                name: "permissionsXuser");

            migrationBuilder.DropTable(
                name: "orders_tracking");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "dealers");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "orders_detail");

            migrationBuilder.DropTable(
                name: "orders_status");

            migrationBuilder.DropIndex(
                name: "IX_users_types_PermissionXuserTypeId",
                table: "users_types");

            migrationBuilder.DropColumn(
                name: "PermissionXuserTypeId",
                table: "users_types");
        }
    }
}
