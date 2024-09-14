namespace Backend.Model
{
    public class Order_Tracking_Type
    {
        public int Id { get; set; }
        public required string OrderTracking_type { get; set; }
        public virtual required Order_Tracking Order_Tracking { get; set; }
    }
}
