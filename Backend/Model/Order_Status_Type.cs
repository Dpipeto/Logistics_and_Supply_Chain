using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Order_Status_Type
    {
        [Key]
        public int Id { get; set; }
        public required string OrderStatus_Type { get; set; }
    }
}
