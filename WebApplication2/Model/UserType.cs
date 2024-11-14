using System.ComponentModel.DataAnnotations;
using SGME.Model;



    public class UserType
    {

        public int Id { get; set; }  // Primary Key
        public required string UserTypeName { get; set; }  // Name of the user type
        public bool IsDeleted { get; internal set; }
        public object PermissionPerUserType { get; internal set; }
}


