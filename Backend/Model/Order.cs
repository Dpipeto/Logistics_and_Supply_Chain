using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string TypeOrder { get; set; }
        public required string Packagesender { get; set; }
        public required string PackageReceive { get; set; }
        public required string OrderValue { get; set; }
        public required string SenderAddress { get; set; }
        public required string SenderPhone { get; set; }
        public required string SenderEmail { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual required User User { get; set; }
        public virtual required OrderDetail Detail { get; set; }
        public virtual required OrderStatusType Status { get; set; }

    }
}
