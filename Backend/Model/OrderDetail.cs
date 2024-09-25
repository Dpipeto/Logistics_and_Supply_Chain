using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public required string Delivery_Time { get; set; }
    }
}
