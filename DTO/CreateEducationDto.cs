using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class CreateEducationDto
    {
        public string Skola { get; set; }
        public string Examen { get; set; }
        public DateOnly StartDatum { get; set; }
        public DateOnly SlutDatum { get; set; }
        
        public int PersonId_FK { get; set; }
    }
}
