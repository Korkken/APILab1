using APILab1.DTO;
using APILab1.Models;

namespace APILab1.Extensions
{
    public static class WorkExperienceExtensions
    {
        public static WorkExpDto ToWorkExpDto(this WorkExperience workExperience)
        {
            return new WorkExpDto
            {
                Company = workExperience.Company,
                Title = workExperience.JobTitle,
                
                
            };
        }
    }
}
