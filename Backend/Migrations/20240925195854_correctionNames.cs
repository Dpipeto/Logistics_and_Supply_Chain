using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class correctionNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_orders_detail_DetailId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_orders_status_StatusId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "order_tracking_types");

            migrationBuilder.DropTable(
                name: "orders_detail");

            migrationBuilder.DropTable(
                name: "orders_status");

            migrationBuilder.DropTable(
                name: "orders_tracking");

            migrationBuilder.RenameColumn(
                name: "Type_Order",
                table: "orders",
                newName: "TypeOrder");

            migrationBuilder.RenameColumn(
                name: "Sender_Phone",
                table: "orders",
                newName: "SenderPhone");

            migrationBuilder.RenameColumn(
                name: "Sender_Email",
                table: "orders",
                newName: "SenderEmail");

            migrationBuilder.RenameColumn(
                name: "Sender_Address",
                table: "orders",
                newName: "SenderAddress");

            migrationBuilder.RenameColumn(
                name: "Package_sender",
                table: "orders",
                newName: "Packagesender");

            migrationBuilder.RenameColumn(
                name: "Package_Receive",
                table: "orders",
                newName: "PackageReceive");

            migrationBuilder.RenameColumn(
                name: "Order_Value",
                table: "orders",
                newName: "OrderValue");

            migrationBuilder.RenameColumn(
                name: "Order_Date",
                table: "dealers",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "Delivery_Date",
                table: "dealers",
                newName: "DeliveryDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "permissionsXuser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "permissions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "dealers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ordersDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordersStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordersTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DealerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersTracking_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordersTracking_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderTrackingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTrackingTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Order_TrackingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTrackingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderTrackingTypes_ordersTracking_Order_TrackingId",
                        column: x => x.Order_TrackingId,
                        principalTable: "ordersTracking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordersTracking_DealerId",
                table: "ordersTracking",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_ordersTracking_OrderId",
                table: "ordersTracking",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderTrackingTypes_Order_TrackingId",
                table: "orderTrackingTypes",
                column: "Order_TrackingId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_ordersDetail_DetailId",
                table: "orders",
                column: "DetailId",
                principalTable: "ordersDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_ordersStatus_StatusId",
                table: "orders",
                column: "StatusId",
                principalTable: "ordersStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_ordersDetail_DetailId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_ordersStatus_StatusId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "ordersDetail");

            migrationBuilder.DropTable(
                name: "ordersStatus");

            migrationBuilder.DropTable(
                name: "orderTrackingTypes");

            migrationBuilder.DropTable(
                name: "ordersTracking");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "permissionsXuser");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "dealers");

            migrationBuilder.RenameColumn(
                name: "TypeOrder",
                table: "orders",
                newName: "Type_Order");

            migrationBuilder.RenameColumn(
                name: "SenderPhone",
                table: "orders",
                newName: "Sender_Phone");

            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "orders",
                newName: "Sender_Email");

            migrationBuilder.RenameColumn(
                name: "SenderAddress",
                table: "orders",
                newName: "Sender_Address");

            migrationBuilder.RenameColumn(
                name: "Packagesender",
                table: "orders",
                newName: "Package_sender");

            migrationBuilder.RenameColumn(
                name: "PackageReceive",
                table: "orders",
                newName: "Package_Receive");

            migrationBuilder.RenameColumn(
                name: "OrderValue",
                table: "orders",
                newName: "Order_Value");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "dealers",
                newName: "Order_Date");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "dealers",
                newName: "Delivery_Date");

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
                name: "orders_tracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Order_TrackingId = table.Column<int>(type: "int", nullable: false),
                    OrderTracking_type = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_order_tracking_types_Order_TrackingId",
                table: "order_tracking_types",
                column: "Order_TrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_tracking_DealerId",
                table: "orders_tracking",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_tracking_OrderId",
                table: "orders_tracking",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orders_detail_DetailId",
                table: "orders",
                column: "DetailId",
                principalTable: "orders_detail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orders_status_StatusId",
                table: "orders",
                column: "StatusId",
                principalTable: "orders_status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
