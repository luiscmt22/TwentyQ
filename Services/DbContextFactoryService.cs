using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TwentyQ.Data;

namespace TwentyQ.Services;

public interface IDbContextFactoryService
{
    TwentyQContext CreateDbContext();
}

public class DbContextFactoryService : IDbContextFactoryService
{
    private readonly IConfiguration _configuration;
    public DbContextFactoryService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TwentyQContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<TwentyQContext>();
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("TwentyQDatabase") ?? "Data Source=twentyq.db");
        return new TwentyQContext(optionsBuilder.Options, _configuration);
    }
}
