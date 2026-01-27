using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TwentyQ.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TwentyQContext>
{
    public TwentyQContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TwentyQContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("TwentyQDatabase"));

        return new TwentyQContext(optionsBuilder.Options, configuration);
    }
}