using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankQueue.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BankQueueDbContext>
{
    public BankQueueDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BankQueueDbContext>();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Ensure correct directory
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new BankQueueDbContext(optionsBuilder.Options);
    }
}
