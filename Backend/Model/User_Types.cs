using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class User_Types
    {
        [Key]
        public int Id { get; set; }
        public required string UserType { get; set; }
        

    }
}
