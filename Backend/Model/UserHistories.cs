using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class UserHistories
    {

        [Key]
        public int Id { get; set; }
        public required string UserId  { get; set; }
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public required string password { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string ID_Document { get; set; }
        public required string UserTypeId { get; set; }
        public required string Date { get; set; }
        public required string ModifiedDate { get; set; }
        public required string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual required User User { get; set; }
        public virtual required UserTypes UserTypes { get; set; }
    }
}
