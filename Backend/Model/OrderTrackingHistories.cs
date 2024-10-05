using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderTrackingHistories
    {

        [Key]
        public int Id { get; set; }
        public int OrderTrackingId { get; set; }
        public required string Date { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
        public required string Order { get; set; }
        public required string Dealer { get; set; }
    }
}
