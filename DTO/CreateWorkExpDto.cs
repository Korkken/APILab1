using System.ComponentModel.DataAnnotations.Schema;

namespace APILab1.DTO
{
    public class CreateWorkExpDto
    {
        public string Jobbtitel { get; set; }
        public string Företag { get; set; }
        public string Beskrivning { get; set; }
        public int StartÅr { get; set; }
        public int SlutÅr { get; set; }
        
        public int PersonId_FK { get; set; }
    }
}
