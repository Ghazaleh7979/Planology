using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database
{
    namespace Planology.Book.Infrastructure
    {
        public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer("Server=localhost;Database=Planology;Integrated Security=True;TrustServerCertificate=True;");

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }
    }
}

