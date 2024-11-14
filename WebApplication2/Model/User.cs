using SGME.Model;
using System.ComponentModel.DataAnnotations;

namespace SGME.Model
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual required UserType UserType { get; set; }
        public object ContentUsers { get; set; }
    }
}
