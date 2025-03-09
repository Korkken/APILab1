using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.Models
{
    public class WorkExperience
    {
        [Key]
        public int Id { get; init; }
        public required string JobTitle { get; set; }
        public required string Company { get; set; }
        public required string WorkDescription { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
        [ForeignKey("Person")]
        public int? PersonId_FK { get; set; } 
        public virtual PersonInfo? Person { get; set; }
    }
}
