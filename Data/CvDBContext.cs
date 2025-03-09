using APILab1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace APILab1.Data
{
    public class CvDBContext : DbContext
    {
        public CvDBContext(DbContextOptions<CvDBContext> options) : base(options)
        {
            
        }
        
        public DbSet<PersonInfo> PersonInfos { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }

        public DbSet<CV> CVs { get; set; }
    }
    public class CVContextFactory : IDesignTimeDbContextFactory<CvDBContext>
    {
        public CvDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CvDBContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Database = CVDB; Integrated Security = True; Encrypt = True; Trust Server Certificate = True;");

            return new CvDBContext(optionsBuilder.Options);
        }
    }
}

