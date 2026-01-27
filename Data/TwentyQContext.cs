using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TwentyQ.Entities;

namespace TwentyQ.Data;

public class TwentyQContext : DbContext
{
    protected readonly IConfiguration Configuration;

    protected TwentyQContext()
    {
    }

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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Questions
        modelBuilder.Entity<QuestionEntity>().HasData(
            new QuestionEntity { Id = 1, Text = "Does it fly?" },
            new QuestionEntity { Id = 2, Text = "Does it swim?" },
            new QuestionEntity { Id = 3, Text = "Is it a mammal?" },
            new QuestionEntity { Id = 4, Text = "Is it a bird?" }
        );

        // Seed Animals
        modelBuilder.Entity<AnimalEntity>().HasData(
            new AnimalEntity { Id = 1, Name = "Penguin" },
            new AnimalEntity { Id = 2, Name = "Dog" },
            new AnimalEntity { Id = 3, Name = "Eagle" },
            new AnimalEntity { Id = 4, Name = "Shark" },
            new AnimalEntity { Id = 5, Name = "Cat" },
            new AnimalEntity { Id = 6, Name = "Whale" },
            new AnimalEntity { Id = 7, Name = "Bat" },
            new AnimalEntity { Id = 8, Name = "Salmon" }
        );

        // Seed Answers
        // Format: [Fly, Swim, Mammal, Bird] where 0=No, 1=Maybe, 2=Yes
        modelBuilder.Entity<AnimalAnswerEntity>().HasData(
            // Penguin: [0, 2, 0, 2]
            new AnimalAnswerEntity { Id = 1, AnimalId = 1, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 2, AnimalId = 1, QuestionId = 2, Value = 2 },
            new AnimalAnswerEntity { Id = 3, AnimalId = 1, QuestionId = 3, Value = 0 },
            new AnimalAnswerEntity { Id = 4, AnimalId = 1, QuestionId = 4, Value = 2 },

            // Dog: [0, 0, 2, 0]
            new AnimalAnswerEntity { Id = 5, AnimalId = 2, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 6, AnimalId = 2, QuestionId = 2, Value = 0 },
            new AnimalAnswerEntity { Id = 7, AnimalId = 2, QuestionId = 3, Value = 2 },
            new AnimalAnswerEntity { Id = 8, AnimalId = 2, QuestionId = 4, Value = 0 },

            // Eagle: [2, 0, 0, 2]
            new AnimalAnswerEntity { Id = 9, AnimalId = 3, QuestionId = 1, Value = 2 },
            new AnimalAnswerEntity { Id = 10, AnimalId = 3, QuestionId = 2, Value = 0 },
            new AnimalAnswerEntity { Id = 11, AnimalId = 3, QuestionId = 3, Value = 0 },
            new AnimalAnswerEntity { Id = 12, AnimalId = 3, QuestionId = 4, Value = 2 },

            // Shark: [0, 2, 0, 0]
            new AnimalAnswerEntity { Id = 13, AnimalId = 4, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 14, AnimalId = 4, QuestionId = 2, Value = 2 },
            new AnimalAnswerEntity { Id = 15, AnimalId = 4, QuestionId = 3, Value = 0 },
            new AnimalAnswerEntity { Id = 16, AnimalId = 4, QuestionId = 4, Value = 0 },

            // Cat: [0, 0, 2, 0]
            new AnimalAnswerEntity { Id = 17, AnimalId = 5, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 18, AnimalId = 5, QuestionId = 2, Value = 0 },
            new AnimalAnswerEntity { Id = 19, AnimalId = 5, QuestionId = 3, Value = 2 },
            new AnimalAnswerEntity { Id = 20, AnimalId = 5, QuestionId = 4, Value = 0 },

            // Whale: [0, 2, 2, 0]
            new AnimalAnswerEntity { Id = 21, AnimalId = 6, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 22, AnimalId = 6, QuestionId = 2, Value = 2 },
            new AnimalAnswerEntity { Id = 23, AnimalId = 6, QuestionId = 3, Value = 2 },
            new AnimalAnswerEntity { Id = 24, AnimalId = 6, QuestionId = 4, Value = 0 },

            // Bat: [2, 0, 2, 0]
            new AnimalAnswerEntity { Id = 25, AnimalId = 7, QuestionId = 1, Value = 2 },
            new AnimalAnswerEntity { Id = 26, AnimalId = 7, QuestionId = 2, Value = 0 },
            new AnimalAnswerEntity { Id = 27, AnimalId = 7, QuestionId = 3, Value = 2 },
            new AnimalAnswerEntity { Id = 28, AnimalId = 7, QuestionId = 4, Value = 0 },

            // Salmon: [0, 2, 0, 0]
            new AnimalAnswerEntity { Id = 29, AnimalId = 8, QuestionId = 1, Value = 0 },
            new AnimalAnswerEntity { Id = 30, AnimalId = 8, QuestionId = 2, Value = 2 },
            new AnimalAnswerEntity { Id = 31, AnimalId = 8, QuestionId = 3, Value = 0 },
            new AnimalAnswerEntity { Id = 32, AnimalId = 8, QuestionId = 4, Value = 0 }
        );
    }

}
