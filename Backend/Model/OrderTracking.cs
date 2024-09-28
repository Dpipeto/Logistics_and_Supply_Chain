using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderTracking
    {
        [Key]
        public int Id { get; set; }
        public required string Date { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual required Order Order { get; set; }
        public virtual required Dealer Dealer { get; set; }
    }
}
