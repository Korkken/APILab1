using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class UpdateEducationDto
    {
        public string? Skola { get; init; }
        public string? Examen { get; init; }
        public DateOnly? StartDatum { get; init; }
        public DateOnly? SlutDatum { get; init; }

    }
}
