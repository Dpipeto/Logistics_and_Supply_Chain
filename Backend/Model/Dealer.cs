using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public required string OrderDate { get; set; }
        public required string DeliveryDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual required User User { get; set; }
    }
}
