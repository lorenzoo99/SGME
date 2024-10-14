using System.Security;

namespace SGME.Model
{
    public class PermissionPerUserType
    {
        // Composite Primary Key
        public int PermissionPerUserTypeID { get; set; }
        public required int UserTypeID { get; set; }  // Navigation property

        public required UserType UserType { get; set; }
        public int PermissionID { get; set; }
        public virtual required Permissions Permission { get; set; }  // Navigation property
        public bool IsDeleted { get; internal set; }
    }
}