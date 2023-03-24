using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=shop;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
