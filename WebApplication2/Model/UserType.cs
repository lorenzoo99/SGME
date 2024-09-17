using System.ComponentModel.DataAnnotations;
using SGME.Model;

namespace SGME.Model
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        
    }
}
