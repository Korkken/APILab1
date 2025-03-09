using APILab1.Data;
using APILab1.DTO;
using APILab1.Extensions;
using APILab1.Models;
using APILab1.Services;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json;

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
                    Name = newPerson.Name,
                    Description = newPerson.Description,
                    ContactDetails = newPerson.ContactDetails,
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
                    School = newEducation.School,
                    Degree = newEducation.Degree,
                    StartDate = newEducation.StartDate,
                    EndDate = newEducation.EndDate,
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
                    JobTitle = newWorkExp.JobTitle,
                    Company = newWorkExp.Company,
                    WorkDescription = newWorkExp.WorkDescription,
                    StartYear = newWorkExp.StartYear,
                    EndYear = newWorkExp.EndYear,
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

            app.MapPatch("/WorkExperience", async (CvDBContext context, int id, UpdateWorkExperienceDto workExperience) =>
            {
                var existingWorkExperience = await context.WorkExperiences
                    .SingleOrDefaultAsync(w => w.Id == id);

                if (existingWorkExperience == null)
                {
                    return Results.NotFound($"Jobb med ID {id} hittades inte.");
                }
                if (workExperience.JobTitle != null)
                    existingWorkExperience.JobTitle = workExperience.JobTitle;
                if (workExperience.Company != null)
                    existingWorkExperience.Company = workExperience.Company;
                if (workExperience.WorkDescription != null)
                    existingWorkExperience.WorkDescription = workExperience.WorkDescription;
                if (workExperience.StartYear != null)
                    existingWorkExperience.StartYear = workExperience.StartYear;
                if (workExperience.EndYear != null)
                    existingWorkExperience.EndYear = workExperience.EndYear;

                await context.SaveChangesAsync();

                return Results.Ok(existingWorkExperience.ToWorkExpDto());

            });

            app.MapDelete("/WorkExperience", (CvDBContext context, int id) =>
            {
                var WorkExperience = context.WorkExperiences.SingleOrDefault(w => w.Id == id);

                if (WorkExperience == null)
                {
                    return Results.NotFound("Workexperience not found");
                }
                context.WorkExperiences.Remove(WorkExperience);
                context.SaveChanges();

                return Results.Ok();

            });

            app.MapDelete("/Education", (CvDBContext context, int id) =>
            {
                var Education = context.Educations.SingleOrDefault(e => e.Id == id);

                if (Education == null)
                {
                    return Results.NotFound("Education not found");
                }
                context.Educations.Remove(Education);
                context.SaveChanges();

                return Results.Ok();

            });

            app.MapGet("/api/github/repos/{username}", async (HttpClient client, string username) =>
            {

                {
                    string url = $"https://api.github.com/users/{username}/repos";
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(responseData);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode}");
                        }

                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var repos = JsonSerializer.Deserialize<List<GithubRepo>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        var result = repos?.ConvertAll(repo => new
                        {
                            repositoryName = repo.Name,
                            Language = string.IsNullOrEmpty(repo.Language) ? "okänt" : repo.Language,
                            Description = string.IsNullOrEmpty(repo.Description) ? "saknas" : repo.Description,
                            RepositoryUrl = repo.Html_Url
                        });

                        return Results.Ok(result);
                    }
                    catch (Exception ex)
                    {
                        return Results.Problem($"Server error: {ex.Message}");
                    }



                }
            });
        }

    }
}

