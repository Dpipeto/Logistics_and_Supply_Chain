using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class PermissionXuserType
    {
        [Key]
        public int Id { get; set; }
        public required string PermissionsXuserType { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual required Permissions Permissions { get; set; }
    }
}
