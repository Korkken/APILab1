using APILab1.Data;
using APILab1.DTO;
using APILab1.Extensions;
using APILab1.Models;
using APILab1.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace APILab1.Endpoints
{
    public class CvEndpoints
    {
        public static void RegisterEndpoints(WebApplication app)
        {
            app.MapGet("GetAllPersons", async (CVService cvService) =>
            {
                return await cvService.GetAllPersons();
            });

            app.MapGet("GetAllEducations", async (CVService cvService) =>
            {
                return await cvService.GetAllEducations();
            });

            app.MapGet("GetAllWork", async (CVService cvService) =>
            {
                return await cvService.GetAllWork();
            });

            app.MapGet("/personInfo/{id}", async (CvDBContext context, int id) =>
            {
                var personList = await context.PersonInfos
                    .Where(p => p.Id == id) 
                    .Select(p => new PersonDto
                    {
                        personName = p.Name,
                        Id = p.Id
                    })
                    .ToListAsync();

                return Results.Ok(personList);
            });

            app.MapPost("/personInfo", async (CreatePersonDto newPerson, CvDBContext context) =>
            {
                var validationContext = new ValidationContext(newPerson);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newPerson, validationContext, validationResult);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(validationResult => validationResult.ErrorMessage));
                }

                var personInfo = new PersonInfo
                {
                    Name = newPerson.Namn,
                    Description = newPerson.Beskrivning,
                    ContactDetails = newPerson.Kontaktuppgifter,
                };

                context.PersonInfos.Add(personInfo);
                await context.SaveChangesAsync();

                return Results.Ok(personInfo);
            });

            app.MapPost("/education", async (CreateEducationDto newEducation, CvDBContext context) =>
            {
                var validationContext = new ValidationContext(newEducation);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newEducation, validationContext, validationResult);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(validationResult => validationResult.ErrorMessage));
                }

                var education = new Education
                {
                     School = newEducation.Skola,
                     Degree = newEducation.Examen,
                     StartDate = newEducation.StartDatum,
                     EndDate = newEducation.SlutDatum,
                     PersonId_FK = newEducation.PersonId_FK,
                };

                context.Educations.Add(education);
                await context.SaveChangesAsync();

                return Results.Ok(education);

            });

            app.MapPost("/workExperience", async (CreateWorkExpDto newWorkExp, CvDBContext context) =>
            {
                var validationContext = new ValidationContext(newWorkExp);
                var validationResult = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(newWorkExp, validationContext, validationResult);

                if (!isValid)
                {
                    return Results.BadRequest(validationResult.Select(validationResult => validationResult.ErrorMessage));
                }

                var workExp = new WorkExperience
                {
                    JobTitle = newWorkExp.Jobbtitel,
                    Company = newWorkExp.Företag,
                    WorkDescription = newWorkExp.Beskrivning,
                    StartYear = newWorkExp.StartÅr,
                    EndYear = newWorkExp.SlutÅr,
                    PersonId_FK = newWorkExp.PersonId_FK
                };

                context.WorkExperiences.Add(workExp);
                await context.SaveChangesAsync();

                return Results.Ok(workExp);

            });

            app.MapPatch("/educations/{id}", async (CvDBContext context, int id, UpdateEducationDto education) =>
            {
                var existingEducation = await context.Educations
                    .SingleOrDefaultAsync(e => e.Id == id);

                if (existingEducation == null)
                {
                    return Results.NotFound($"Utbildning med ID {id} hittades inte.");
                }
                if (education.StartDatum.HasValue)
                    existingEducation.StartDate = education.StartDatum.Value;
                if (education.SlutDatum.HasValue)
                    existingEducation.EndDate = education.SlutDatum.Value;
                if (education.Skola != null)
                    existingEducation.School = education.Skola;
                if (education.Examen != null)
                    existingEducation.Degree = education.Examen;

                await context.SaveChangesAsync();

                return Results.Ok(existingEducation.ToEducationDto());
            });

        }

    }
}

