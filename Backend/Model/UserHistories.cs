using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class UserHistories
    {

        [Key]
        public int Id { get; set; }
        public virtual required User User { get; set; }
        public required string password { get; set; }
        public virtual required UserTypes UserType { get; set; }
        public required string Date { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
