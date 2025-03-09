using System.ComponentModel.DataAnnotations;

namespace APILab1.Models
{
    public class PersonInfo
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ContactDetails { get; set; }
        public List<Education> Educations { get; set; } = [];
        public List<WorkExperience> WorkExperiences { get; set; } = [];
    }
}
