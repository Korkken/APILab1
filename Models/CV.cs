using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Person")]
        public int PersonId_FK { get; set; }
        public PersonInfo Person { get; set; }
        public List<Education> Educations { get; set; } = new List<Education>();
        public List<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
    }
}
