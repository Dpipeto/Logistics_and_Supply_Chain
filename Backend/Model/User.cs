using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string First_Name { get; set; }
        public required string Last_Name { get; set; }
        public  required string Username {  get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required string ID { get; set; }
        public required string Date { get; set; }
    }
}
