using System.ComponentModel.DataAnnotations;

namespace Backend.Model 
{
    public class OrderDetailHistories
    {
        [Key]
        public int Id { get; set; }
        public required string OrderDetailId { get; set; }
        public virtual required OrderDetail OrderDetail { get; set; }
        public required string DeliveriTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
