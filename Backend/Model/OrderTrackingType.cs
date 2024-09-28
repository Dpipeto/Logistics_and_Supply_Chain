using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderTrackingType

    {
        [Key]
        public int Id { get; set; }
        public required string OrderTrackingTypes { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual required OrderTracking Order_Tracking { get; set; }
    }
}
