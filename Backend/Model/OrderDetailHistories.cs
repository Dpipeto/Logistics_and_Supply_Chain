using System.ComponentModel.DataAnnotations;

namespace Backend.Model 
{
    public class OrderDetailHistories
    {
        [Key]
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public required string DeliveriTime { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
