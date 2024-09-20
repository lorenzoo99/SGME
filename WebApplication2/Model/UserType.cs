using System.ComponentModel.DataAnnotations;
using SGME.Model;

namespace SGME.Model
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }  // Primary Key
        public required string Name { get; set; }
        public required string UserTypeName { get; set; }  // Name of the user type
        public required string UserTypeDescription { get; set; }  // Description of the user type

        // Navigation property: collection of users associated with this type
        public virtual required ICollection<User> Users { get; set; }
        public virtual required ICollection<PermissionPerUserType> PermissionPerUserType { get; set; }
    }

}
