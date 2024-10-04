using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Void : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
            /// Trigger Order
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_Order
     ON[orders]
     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO ordersHistories(OrderId, TypeOrder, PackageSender, PackageReceive, OrderValue, SenderAddress, SenderPhone, SenderEmail, [User], OrderDetail, OrderStatusType, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.TypeOrder, i.PackageSender, i.PackageReceive, i.OrderValue, i.SenderAddress, i.SenderPhone, i.SenderEmail, i.UserId, i.DetailId, i.StatusId,
                 GETDATE(),
                    CASE
                        WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                        ELSE 'INSERT'
                    END
             FROM inserted i;
     END

     -- If there are deleted records
     IF EXISTS(SELECT * FROM deleted)
         BEGIN
             INSERT INTO ordersHistories(OrderId, TypeOrder, PackageSender, PackageReceive, OrderValue, SenderAddress, SenderPhone, SenderEmail, [User], OrderDetail, OrderStatusType, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.TypeOrder, d.PackageSender, d.PackageReceive, d.OrderValue, d.SenderAddress, d.SenderPhone, d.SenderEmail, d.UserId, d.DetailId, d.StatusId, GETDATE(), 'DELETE'
                   FROM deleted d;
     END
 END;
     ");
            /// <inheritdoc />
            /// Trigger OrderTracking
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_OrderTracking
     ON[ordersTraking]
     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO ordersTrackingHistories(OrderId, Date, [order], Dealer, ModifiedDate, ModifiedBy)
                GETDATE(),
                    CASE
                        WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                        ELSE 'INSERT'
                    END
             FROM inserted i;
     END

     -- If there are deleted records
     IF EXISTS(SELECT * FROM deleted)
         BEGIN
             INSERT INTO ordersTrackingHistories(OrderId, Date, [order], Dealer, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.Date, d.OrderId, d.DealerId, GETDATE(), 'DELETE'
                   FROM deleted d;
     END
 END;
     ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_Order;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_OrderTracking;");
        }
    }
}
