using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderHistories
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public required string TypeOrder { get; set; }
        public required string Packagesender { get; set; }
        public required string PackageReceive { get; set; }
        public required string OrderValue { get; set; }
        public required string SenderAddress { get; set; }
        public required string SenderPhone { get; set; }
        public required string SenderEmail { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
        public required string User { get; set; }
        public required string OrderDetail { get; set; }
        public required string OrderStatusType { get; set; }
    }
}
