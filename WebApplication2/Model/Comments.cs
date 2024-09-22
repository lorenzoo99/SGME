using System.ComponentModel.DataAnnotations;
using SGME.Model;

namespace SGME.Model
{
    public class Comments
    {
        [Key]
        public int CommentsId { get; set; }

        public required int UserId { get; set; }

        public required int RefferencesId { get; set; }

        public required string Comment { get; set; }

        public required DateTime CommentDate { get; set; }

        public required DateTime Modified { get; set; }

    
    }
}
