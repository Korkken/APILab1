using APILab1.DTO;
using APILab1.Models;

namespace APILab1.Extensions
{
    public static class EducationExtensions
    {
        public static EducationDto ToEducationDto(this Education education)
        {
            return new EducationDto 
            { 
                Degree = education.Degree,
                SchoolName = education.School
            };
        }
    }
}
