using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class CreateWorkExpDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string WorkDescription { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        
        public int PersonId_FK { get; set; }
    }
}
