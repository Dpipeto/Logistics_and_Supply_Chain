namespace Backend.Model
{
    public class OrderTracking
    {
        public int Id { get; set; }
        public required string Date { get; set; }
        public virtual required Order Order { get; set; }
        public virtual required Dealer Dealer { get; set; }
    }
}
