using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public required string School { get; set; }
        public required string Degree { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        [ForeignKey("Person")]
        public int? PersonId_FK { get; set; } 
        public virtual PersonInfo? Person { get; set; }
        
    }
}
