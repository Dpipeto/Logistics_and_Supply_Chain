using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class PermissionXuserType
    {
        [Key]
        public int Id { get; set; }
        public virtual required UserTypes UserTypes { get; set; }
        public virtual required Permissions Permissions { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
