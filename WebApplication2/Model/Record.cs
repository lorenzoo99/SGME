using System.ComponentModel.DataAnnotations;
using SGME.Model;

namespace SGME.Model
{
    
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        public required int UserId { get; set; }

        public required int UserTypeId { get; set; }

        public required string ReferenceId { get; set; }

        public required DateTime Date { get; set; }

        


    }
}