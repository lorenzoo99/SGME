namespace SGME.Model
{
    public class Permissions
    {
            public int PermissionID { get; set; }  // Primary Key
            public required string PermissionName { get; set; }
            public required string PermissionDescription { get; set; }

            // Navigation property for related UserTypes
            public virtual required ICollection<PermissionPerUserType> PermissionPerUserTypes { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
