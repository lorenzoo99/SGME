using SGME.Model;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string UserState { get; set; }

        public required DateTime Date { get; set; }

        public virtual required UserType UserType { get; set; }

       

    }
}
