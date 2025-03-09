using APILab1.Data;
using APILab1.Models;
using APILab1.DTO;
using Microsoft.EntityFrameworkCore;
namespace APILab1.Services
{
    public class CVService
    {
        private readonly CvDBContext context;

        public CVService(CvDBContext _context)
        {
            context = _context;
        }

        public async Task<List<PersonDto>> GetAllPersons()
        {
            var PersonList = await context.PersonInfos.Select(p => new PersonDto
            {
                personName = p.Name,
                Id = p.Id,

            }).ToListAsync();

            return PersonList;
        }

        public async Task<List<EducationDto>> GetAllEducations()
        {
            var EducationList = await context.Educations.Select(e => new EducationDto
            {
                SchoolName = e.School,
                Degree = e.Degree
            }).ToListAsync();

            return EducationList;
        }

        public async Task<List<WorkExpDto>> GetAllWork()
        {
            var WorkList = await context.WorkExperiences.Select(w => new WorkExpDto
            {
                Title = w.JobTitle,
                Company = w.Company
            }).ToListAsync();

            return WorkList;
        }
    }
}

