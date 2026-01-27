using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TwentyQ.Entities;

namespace TwentyQ.Data;

public class TwentyQContext : DbContext
{
    protected readonly IConfiguration Configuration;

    protected TwentyQContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public TwentyQContext(DbContextOptions<TwentyQContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<AnimalEntity> Animals { get; set; } = null!;
    public DbSet<QuestionEntity> Questions { get; set; } = null!;
    public DbSet<AnimalAnswerEntity> AnimalAnswers { get; set; } = null!;


}
