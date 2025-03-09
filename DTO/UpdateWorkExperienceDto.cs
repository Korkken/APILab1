using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class UpdateWorkExperienceDto
    {
        public string? JobTitle { get; init; }
        public string? Company { get; init; }
        public string? WorkDescription { get; init; }
        public int? StartYear { get; init; }
        public int? EndYear { get; init; }
    }
}
