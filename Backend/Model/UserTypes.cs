using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        public required string UserType { get; set; }
        public bool IsDeleted { get; set; }
        public virtual required PermissionXuserType PermissionXuserType { get; set; }

    }
}
