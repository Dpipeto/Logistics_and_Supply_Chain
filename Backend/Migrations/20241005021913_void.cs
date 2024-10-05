using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class @void : Migration
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
            /// Trigger User
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_User
     ON[users]
     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO userHistories(UserId, First_Name, Last_Name, Username, Email, Password, Address, Phone, Date, ID_Document, UserTypes, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.First_Name, i.Last_Name, i.Username, i.Email, i.Password, i.Address, i.Phone, i.Date, i.ID_Document, i.UserTypeId,
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
             INSERT INTO userHistories(UserId, First_Name, Last_Name, Username, Email, Password, Address, Phone, Date, ID_Document, UserTypes, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.First_Name, d.Last_Name, d.Username, d.Email, d.Password, d.Address, d.Phone, d.Date, d.ID_Document, d.UserTypeId, GETDATE(), 'DELETE'
                   FROM deleted d;
     END
 END;
     ");
            /// <inheritdoc />
            /// Trigger OrderTracking
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_OrderTracking
     ON[ordersTracking]
     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO ordersTrackingHistories(OrderTrackingId, Date, [order], Dealer, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.Date, i.OrderId, i.DealerId,
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
             INSERT INTO ordersTrackingHistories(OrderTrackingId, Date, [order], Dealer, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.Date, d.OrderId, d.DealerId, GETDATE(), 'DELETE'
                   FROM deleted d;
     END
 END;
     ");
            /// <inheritdoc />
            /// Trigger OrderDetail
            migrationBuilder.Sql(@"
     CREATE OR ALTER TRIGGER trg_OrderDetail
     ON[ordersDetail]
     AFTER INSERT, UPDATE, DELETE
     AS
     BEGIN
         SET NOCOUNT ON;
     --If there are inserted or updated records
         IF EXISTS(SELECT* FROM inserted)
         BEGIN
             INSERT INTO orderDetailHistories(OrderDetailId, DeliveryTime, ModifiedDate, ModifiedBy)
             SELECT i.Id, i.DeliveryTime,
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
             INSERT INTO orderDetailHistories(OrderDetailId, DeliveryTime, ModifiedDate, ModifiedBy)
             SELECT d.Id, d.DeliveryTime, GETDATE(), 'DELETE'
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
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_OrderDetail;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_User;");
        }
    }
}
