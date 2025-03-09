using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class CreateEducationDto
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        
        public int PersonId_FK { get; set; }
    }
}
