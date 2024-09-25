using System.ComponentModel.DataAnnotations;

namespace Backend.Model
{
    public class Permissions
    {
        [Key]
        public int Id { get; set; }
        public required string Permission {  get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
