using System.Security;

namespace SGME.Model
{
    public class PermissionPerUserType
    {
        // Composite Primary Key
        public int UserTypeID { get; set; }
        public required UserType UserType { get; set; }  // Navigation property

        public int PermissionID { get; set; }
        public virtual required Permissions Permission { get; set; }  // Navigation property
    }
}