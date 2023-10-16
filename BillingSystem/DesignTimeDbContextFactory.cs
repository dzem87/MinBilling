using BillingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BillingContext>
{
    public BillingContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<BillingContext>();
        optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(10, 5, 9))); // Adjust the version accordingly

        return new BillingContext(optionsBuilder.Options);
    }
}
