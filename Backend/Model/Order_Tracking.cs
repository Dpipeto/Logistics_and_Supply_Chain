namespace Backend.Model
{
    public class Order_Tracking
    {
        public int Id { get; set; }
        public required string Date { get; set; }
        public virtual required Order Order { get; set; }
        public virtual required Dealer Dealer { get; set; }
    }
}
