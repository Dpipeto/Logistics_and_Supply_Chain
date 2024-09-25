namespace Backend.Model
{
    public class OrderTrackingType

    {
        public int Id { get; set; }
        public required string OrderTracking_type { get; set; }
        public virtual required OrderTracking Order_Tracking { get; set; }
    }
}
