using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string Type_Order { get; set; }
        public required string Package_sender { get; set; }
        public required string Package_Receive { get; set; }
        public required string Order_Value { get; set; }
        public required string Sender_Address { get; set; }
        public required string Sender_Phone { get; set; }
        public required string Sender_Email { get; set; }

        public virtual required User User { get; set; }
        public virtual required Order_Detail Detail { get; set; }
        public virtual required Order_Status_Type Status { get; set; }

    }
}
