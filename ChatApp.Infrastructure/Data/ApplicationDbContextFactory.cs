using ChatApp.Infrastructure.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChatApp.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=ChatApp;Trusted_Connection=True;MultipleActiveResultSets=true",
            options => options.EnableRetryOnFailure(
                10,
                TimeSpan.FromSeconds(30),
                null));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}