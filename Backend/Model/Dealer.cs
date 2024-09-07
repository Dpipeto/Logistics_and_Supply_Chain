using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public required string Order_Date { get; set; }
        public required string Delivery_Date { get; set; }
    }
}
