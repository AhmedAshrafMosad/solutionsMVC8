using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolManagement.Data;

namespace SchoolManagement.Data
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=SchoolManagementDb2;Trusted_Connection=True;TrustServerCertificate=true;");

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}