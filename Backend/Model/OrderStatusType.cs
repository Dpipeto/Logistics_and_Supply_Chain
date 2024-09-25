using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class OrderStatusType
    {
        [Key]
        public int Id { get; set; }
        public required string OrderStatusTypes { get; set; }
        public bool IsDeleted {  get; set; } = false;
    }
}
